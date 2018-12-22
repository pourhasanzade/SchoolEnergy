using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.Domain.Model
{
    public class KeypadRowModel
    {
        [JsonProperty("buttons")] public List<ButtonModel> Buttons { get; set; }
    }
}