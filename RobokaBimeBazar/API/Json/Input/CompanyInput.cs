using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Input
{
    public class CompanyInput
    {
        [JsonProperty("url_name")]
        public string UrlName => "social_security";
    }
}
