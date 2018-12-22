﻿using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class ButtonLocationModel
    {
        [JsonProperty("default_pointer_location")] public LocationModel DefaultPointerLocation { get; set; }
        [JsonProperty("default_map_location")] public LocationModel DefaultMapLocation { get; set; }
    }
}