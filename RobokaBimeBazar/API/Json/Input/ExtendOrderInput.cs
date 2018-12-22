using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Input
{
    public class ExtendOrderInput : CompleteOrderInput
    {
        [JsonProperty("pickup_address")]
        public AddressInput PickupAddress { get; set; }

        [JsonProperty("pickup_time")]
        public OrderDeliveryTimeInput PickupTime { get; set; }

    }
}