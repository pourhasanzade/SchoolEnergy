using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class CarTypeOutput
    {
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("type_fa")] public string TypeFa { get; set; }
        [JsonProperty("brands")] public List<CarBrandOutput> Brands { get; set; }
    }

    public class CarBrandOutput
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("name_en")] public string NameEn { get; set; }
        [JsonProperty("uses")] public int Uses { get; set; }
        [JsonProperty("logo")] public string Logo { get; set; }
        [JsonProperty("models")] public List<CarModelOutput> Models { get; set; }
    }

    public class CarModelOutput
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("name_en")] public string NameEn { get; set; }
    }
}