using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class ProvincesOutput
    {
        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }

        [JsonProperty("province_name_fa")]
        public string ProvinceNameFa { get; set; }

        [JsonProperty("cities")]
        public List<ProvinceCityOutput> Cities { get; set; }
    }

    public class ProvinceCityOutput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_fa")]
        public string NameFa { get; set; }

        [JsonProperty("phone_prefix")]
        public string PhonePrefix { get; set; }

        [JsonProperty("province")]
        public long Province { get; set; }
    }
}