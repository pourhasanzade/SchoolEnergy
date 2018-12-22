using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class ButtonCallModel
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

    }
}