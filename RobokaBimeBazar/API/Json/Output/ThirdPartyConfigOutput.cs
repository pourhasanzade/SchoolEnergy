using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class ThirdPartyConfigOutput
    {
        [JsonProperty("required_fields")]
        public List<string> RequiredFields { get; set; }

        [JsonProperty("company_required_fields")]
        public CompanyRequiredFields CompanyRequiredFields { get; set; }

        [JsonProperty("accepted_values")]
        public AcceptedValues AcceptedValues { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public class AcceptedValues
    {
        [JsonProperty("liability_property_damage")]
        public List<string> LiabilityPropertyDamage { get; set; }

        [JsonProperty("policy_term")]
        public List<long> PolicyTerm { get; set; }

        [JsonProperty("car_usage")]
        public List<string> CarUsage { get; set; }
    }

    public class CompanyRequiredFields
    {
        [JsonProperty("dana")]
        public List<string> Dana { get; set; }
    }
}