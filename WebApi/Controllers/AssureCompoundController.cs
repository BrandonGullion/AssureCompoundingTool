using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Classes.HealthProductAPIClasses;
using Classes.DTO;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        /// Gets the current list of members that are associated with said memberId
        /// Then check if they are currently on the plan by using DOB and MemberType
        /// </summary>
        /// <param name="memberDTO"></param>
        /// <returns></returns>

        [HttpPost("ValidateMember")]
        public async Task<IActionResult> ValidateMember(MemberDTO memberDTO)
        {
            var members = await _context.Members.Where(m => m.MemberId == memberDTO.MemberId).ToListAsync();

            if (members != null && members.Count > 0)
            {
                var currentMember = members.FirstOrDefault(m => m.DOB == memberDTO.DOB && m.MemberType == memberDTO.MemberType);

                if (currentMember == null)
                    return BadRequest("A member with the provided date of birth and member status could not be found.");

                return Ok();
            }

            return BadRequest("Unable to find any members with the provided Member Id");
        }

        /// <summary>
        /// Validates that the store id that was provided is a current store in the insurance directory 
        /// </summary>
        /// <param name="storeDTO"></param>
        /// <returns></returns>

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
        [HttpPost("CheckCoverage")]
        public async Task<IActionResult> CheckCompoundCoverage(CompoundDTO compoundDTO)
        {
            var httpClient = new HttpClient();



            return BadRequest("Endpoint checkCoverage not configured");
        }
    }
}