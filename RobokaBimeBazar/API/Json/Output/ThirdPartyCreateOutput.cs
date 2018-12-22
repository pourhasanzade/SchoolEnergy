using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class ThirdPartyCreateOutput
    {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("financial_status")]
        public List<object> FinancialStatus { get; set; }

        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }

        [JsonProperty("car_model")]
        public CarModel CarModel { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("car_production_year")]
        public long CarProductionYear { get; set; }

        [JsonProperty("last_policy_exp_date")]
        public string LastPolicyExpDate { get; set; }

        [JsonProperty("years_without_incident")]
        public long YearsWithoutIncident { get; set; }

        [JsonProperty("liability_property_damage")]
        public long LiabilityPropertyDamage { get; set; }

        [JsonProperty("policy_term")]
        public long PolicyTerm { get; set; }

        [JsonProperty("car_usage")]
        public string CarUsage { get; set; }

        [JsonProperty("last_policy_years_without_incident")]
        public object LastPolicyYearsWithoutIncident { get; set; }

        [JsonProperty("num_of_used_property_coupon")]
        public object NumOfUsedPropertyCoupon { get; set; }

        [JsonProperty("num_of_used_person_coupon")]
        public object NumOfUsedPersonCoupon { get; set; }

        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("price_before_tax")]
        public long PriceBeforeTax { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("last_modified_date")]
        public string LastModifiedDate { get; set; }

        [JsonProperty("created_date")]
        public string CreatedDate { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class CarModel
    {
        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("name_fa")]
        public string NameFa { get; set; }

        [JsonProperty("car_brand_name_fa")]
        public string CarBrandNameFa { get; set; }

        [JsonProperty("car_brand_name_en")]
        public string CarBrandNameEn { get; set; }

        [JsonProperty("car_brand_type")]
        public string CarBrandType { get; set; }

        [JsonProperty("car_brand_type_fa")]
        public string CarBrandTypeFa { get; set; }
    }
}