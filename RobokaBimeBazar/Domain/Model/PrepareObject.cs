using RobokaBimeBazar.API.Json.Output;

namespace RobokaBimeBazar.Domain.Model
{
    public class PrepareObject
    {
        public CompleteOrderOutput CompleteOrderOutput { get; set; }
        public PayOutput PayOutput { get; set; }

        public string TrackingCode { get; set; }
    }
}