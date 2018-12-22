using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Output
{
    public class BaseJson
    {
        public StatusCode Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
