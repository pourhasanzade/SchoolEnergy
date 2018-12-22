using System;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class DeliveryTimesOutput
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }

        [JsonProperty("start_fa")]
        public DayFa StartFa { get; set; }

        [JsonProperty("end_fa")]
        public DayFa EndFa { get; set; }
    }

    public class DayFa
    {
        [JsonProperty("week_day")]
        public string WeekDay { get; set; }

        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("hour")]
        public long Hour { get; set; }

        [JsonProperty("minute")]
        public long Minute { get; set; }
    }
}