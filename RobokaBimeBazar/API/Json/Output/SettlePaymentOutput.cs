using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Output
{
    public class SettlePaymentOutput
    {
        [JsonProperty("data")] public SettlePaymentOutputData Data { get; set; }

    }

    public class SettlePaymentOutputData
    {
        [JsonProperty("status")] [JsonConverter(typeof(StringEnumConverter))] public SettleStatusEnum SettleStatus { get; set; }

    }
}