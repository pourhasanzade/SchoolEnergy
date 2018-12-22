using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class ButtonAlertModel
    {
        [JsonProperty("message")] public string Message { get; set; }

    }
}