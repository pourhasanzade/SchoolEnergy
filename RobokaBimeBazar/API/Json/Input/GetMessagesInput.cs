using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;
using RobokaBimeBazar.Domain.Model;

namespace RobokaBimeBazar.API.Json.Input
{
    public class GetMessagesInput
    {
        [JsonProperty("message")] public MessageModel Mesage { get; set; }

        [JsonProperty("type")] public MessageBehaviourTypeEnum Type { get; set; }
    }
}