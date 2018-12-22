using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class ButtonPayment
    {
        [JsonProperty("button_payment_token")] public string ButtonPaymentToken { get; set; }

    }
}