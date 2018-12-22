using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Input
{

    public class AddressCityInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }

        [JsonProperty("phone_prefix")]
        public string PhonePrefix { get; set; }

    }

    public class AddressInput
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        //[JsonProperty("lat")]
        //public object Lat { get; set; }

        //[JsonProperty("lng")]
        //public object Lng { get; set; }

        [JsonProperty("city")]
        public AddressCityInput City { get; set; }

        [JsonProperty("phone_num")]
        public string Phone { get; set; }

    }

    public class OrderDeliveryTimeInput
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }

    public class PolicyHolderInput
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("national_id")]
        public string NationalId { get; set; }

        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        [JsonProperty("father_name")]
        public string FatherName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public PolicyHolderAddressInput Address { get; set; }

        [JsonProperty("phone_num")]
        public string PhoneNum { get; set; }

        //[JsonProperty("policy_address_source")]
        //public string PolicyAddressSource { get; set; }
    }

    public class PolicyHolderAddressInput
    {
        [JsonProperty("address")]
        public string AddressText { get; set; }

        [JsonProperty("city")]
        public AddressCityInput City { get; set; }
    }
}
