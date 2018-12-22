using System;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public partial class ExtendOrderOutput
    {
        [JsonProperty("uid")]
        public string UId { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

    }
}