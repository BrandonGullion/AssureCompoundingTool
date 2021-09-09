using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Classes.HealthProductAPIClasses;
using Classes.DTO;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Classes;
using System;
using Microsoft.AspNetCore.Authorization;
using API.Helpers;
using System.Collections.Generic;

namespace API.Controllers
{
    /// <summary>
    /// Should data be automatically added if it does not exist at the time?
    /// 
    /// </summary>

    public class AssureCompoundController : BaseApiController
    {
        private readonly DataContext _context;
        public AssureCompoundController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Validates that the store id that was provided is a current store in the insurance directory 
        /// </summary>
        /// <param name="storeDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ValidateStore")]
        public async Task<IActionResult> ValidateStore(StoreDTO storeDTO)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(s => s.StoreId == storeDTO.StoreId);

            if (store == null)
                return BadRequest("This store is not currently registered. Please contact support for further assistance");

            return Ok();
        }


        /// <summary>
        /// Validates all ingredients against the inelligible table to determine if there are any present. 
        /// If not then it will check against the users plan itself for non-covered ingredients
        /// If it passes then it will save the compound to the system and return a confirmation number
        /// </summary>
        /// <param name="compoundDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("CheckCoverage")]
        public async Task<IActionResult> CheckCompoundCoverage(CompoundDTO compoundDTO)
        {
            var ineligible = false;
            var coveredUnderPlan = false;
            var httpClient = new HttpClient();
            var response = new ResponseEntity<Ingredient>{ Errors = new List<Error>() };

            compoundDTO.Ingredients.ForEach(async ingredient =>
            {
                var inDb = _context.Ingredients.Any(x => x.DIN == ingredient.DIN || x.Name.ToLower() == ingredient.Name.ToLower());

                // If not in db query for the drug
                if (!inDb)
                {
                    response = ingredient.IngredientType == IngredientType.Normal ? await QueryDrugDIN(ingredient) : await QueryDrugActiveIngredient(ingredient);
                }

                ineligible = await _context.InEligibleIngredients.AnyAsync(x => x.Name.ToUpper() == ingredient.Name.ToUpper());

                if (ineligible)
                    return;
            });

            // Handle any errors that may have happened
            if (response.Errors.Count > 0)
                return BadRequest(response.Errors);

            // Return if the drug is not covered
            if (ineligible || !coveredUnderPlan)
                return Ok("One or more ingredients are not covered under the plan");

            // From this point generate a reference 
            var reference = new Reference
            {
                StoreId = compoundDTO.StoreId,
                MemberId = compoundDTO.MemberId,
                ReferenceNumber = DateTime.Now.ToString("ddMMyyyyhhmmss")
            };

            // Create a reference and add it to the DB
            _context.References.Add(reference);
            await _context.SaveChangesAsync();

            return Ok(new { Reference = reference, Covered = true });
        }


        /// <summary>
        /// Queries the health product API to try and find any drugs that are not currently part of the DB
        /// Should only be used when the drugType is NORMAL or DIN is known
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public async Task<ResponseEntity<Ingredient>> QueryDrugDIN(Ingredient ingredient)
        {
            var httpClient = new HttpClient();
            var ingredientToSave = new Ingredient();
            var responseEntity = new ResponseEntity<Ingredient>();

            var response = await httpClient.GetAsync($"https://health-products.canada.ca/api/drug/drugproduct/?din={ingredient.DIN}");

            // If the DIN api call succeeded, then save the DIN value to ingredient and make another API call using the 
            // Drug code that was obtained
            if (response.IsSuccessStatusCode)
            {
                var DINResult = await response.Content.ReadAsAsync<DrugProductResponse>();

                // Make sure that the result is not null and that the DIN number is not null before proceeding
                if (DINResult != null && DINResult.DrugIdentificationNumber != null)
                {
                    ingredientToSave.DIN = Int32.Parse(DINResult.DrugIdentificationNumber);
                    ingredientToSave.DrugCode = DINResult.DrugCode;

                    var drugCodeResponse = await httpClient.GetAsync($"https://health-products.canada.ca/api/drug/activeingredient/?id={DINResult.DrugCode}");

                    // If the API call using the drug code succeeded, read the data and save the values to ingredient
                    if (drugCodeResponse.IsSuccessStatusCode)
                    {
                        var drugCodeResult = await drugCodeResponse.Content.ReadAsAsync<ActiveIngredientResponse>();
                        ingredientToSave.Name = drugCodeResult.IngredientName;
                        ingredientToSave.Strength = drugCodeResult.Strength;
                    }
                    else if (!drugCodeResponse.IsSuccessStatusCode)
                        responseEntity.Errors.Add(new Error { Message = $"Unable to locate any Entity with the provided Drug Code : {DINResult.DrugCode}" });
                }
                else
                    responseEntity.Errors.Add(new Error { Message = $"Unable to locate any Entity with the provided DIN : {ingredient.DIN}" });
            }

            if (!response.IsSuccessStatusCode)
                responseEntity.Errors.Add(new Error { Message = "Unable to contact Health Products API" });

            // If any errors were encountered make sure to just return the reponse entity
            if (responseEntity.Errors.Count > 0)
                return responseEntity;

            // If no errors, save the ingredient to the db and add to returning response Entity
            _context.Ingredients.Add(ingredientToSave);
            _context.SaveChanges();

            responseEntity.ResponseObject = ingredientToSave;

            return responseEntity;
        }

        /// <summary>
        /// Queries the health product API to try and find any drugs that are not currently part of the DB
        /// Should only be used when the active ingredient is one of the only props that are known and Drug 
        /// Type is POWDER
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public async Task<ResponseEntity<Ingredient>> QueryDrugActiveIngredient(Ingredient ingredient)
        {
            var httpClient = new HttpClient();
            var ingredientToSave = new Ingredient();
            var responseEntity = new ResponseEntity<Ingredient>();

            var response = await httpClient.GetAsync($"https://health-products.canada.ca/api/drug/activeingredient/?ingredientname={ingredient.Name}");

            if (response.IsSuccessStatusCode)
            {
                var activeIngredientResult = await response.Content.ReadAsAsync<ActiveIngredientResponse>();

                // If not null, populate the ingredient to save and save to Db
                if (activeIngredientResult != null)
                {
                    ingredientToSave.Name = ingredient.Name.ToUpper();
                    ingredientToSave.DrugCode = activeIngredientResult.DrugCode;

                    responseEntity.ResponseObject = ingredientToSave;

                    return responseEntity;
                }
                else
                    responseEntity.Errors.Add(new Error { Message = "There was an error communicating active ingredient name to health product server" });
            }
            else
                responseEntity.Errors.Add(new Error { Message = "Unable to reach the health products API" });

            return responseEntity;
        }
    }
}