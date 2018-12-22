using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Input
{
    public class CreateOrderOutput
    {        
        [JsonProperty("uid")]
        public string UId { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}