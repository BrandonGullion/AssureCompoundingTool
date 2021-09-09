using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.HealthProductAPIClasses
{
    public class ActiveIngredientResponse
    {
        [JsonProperty("dosage_unit")]
        public string DosageUnit { get; set; }

        [JsonProperty("dosage_value")]
        public string DosageValue { get; set; }

        [JsonProperty("drug_code")]
        public int DrugCode { get; set; }

        [JsonProperty("ingredient_name")]
        public string IngredientName { get; set; }

        [JsonProperty("strength")]
        public string Strength { get; set; }

        [JsonProperty("strength_unit")]
        public string StrengthUnit { get; set; }
    }
}
