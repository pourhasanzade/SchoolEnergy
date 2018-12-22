using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Input
{
    public class PayInput
    {
        [JsonProperty("cell_num")] public string Mobile { get; set; }

    }
}