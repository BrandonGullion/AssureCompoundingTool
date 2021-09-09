using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.HealthProductAPIClasses
{
    public class DrugProductResponse
    {
        [JsonProperty("drug_code")]
        public int DrugCode { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("drug_identification_number")]
        public string DrugIdentificationNumber { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }

        [JsonProperty("number_of_ais")]
        public string NumberOfAis { get; set; }

        [JsonProperty("ai_group_no")]
        public string AiGroupNo { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("last_update_date")]
        public string LastUpdateDate { get; set; }


    }
}
