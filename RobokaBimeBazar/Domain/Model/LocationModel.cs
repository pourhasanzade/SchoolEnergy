using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class LocationModel
    {
        [JsonProperty("long")] public string Long { get; set; }
        [JsonProperty("lat")] public string Lat { get; set; }

    }
}