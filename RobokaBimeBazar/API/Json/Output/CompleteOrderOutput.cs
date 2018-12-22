using System;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public partial class CompleteOrderOutput
    {
        [JsonProperty("policy_holder")]
        public PolicyHolderOutput PolicyHolder { get; set; }

        [JsonProperty("delivery_address")]
        public AddressOutput DeliveryAddress { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        //[JsonProperty("car_id_card_front")]
        //public string CarIdCardFront { get; set; }

        //[JsonProperty("car_id_card_back")]
        //public string CarIdCardBack { get; set; }

        //[JsonProperty("last_policy_image")]
        //public string LastPolicyImage { get; set; }

        //[JsonProperty("car_id_green_card")]
        //public string CarIdGreenCard { get; set; }

        [JsonProperty("price_before_tax")]
        public long PriceBeforeTax { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("last_modified_date")]
        public DateTimeOffset LastModifiedDate { get; set; }

        [JsonProperty("created_date")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("delivery_time")]
        public OrderDeliveryTimeOutput DeliveryTime { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class AddressOutput
    {
        [JsonProperty("address")]
        public string AddressAddress { get; set; }

        [JsonProperty("city")]
        public AddressCityOutput City { get; set; }

        [JsonProperty("lat")]
        public object Lat { get; set; }

        [JsonProperty("lng")]
        public object Lng { get; set; }
    }

    public class AddressCityOutput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_fa")]
        public string NameFa { get; set; }

        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }

        [JsonProperty("province_name_fa")]
        public string ProvinceNameFa { get; set; }
    }

    public class OrderDeliveryTimeOutput
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }

    public  class PolicyHolderOutput
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("phone_num")]
        public string PhoneNum { get; set; }

        [JsonProperty("cell_num")]
        public string CellNum { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("birth_date")]
        public DateTimeOffset BirthDate { get; set; }

        [JsonProperty("national_id")]
        public string NationalId { get; set; }

        [JsonProperty("policy_address_source")]
        public string PolicyAddressSource { get; set; }

        [JsonProperty("address")]
        public AddressOutput Address { get; set; }
    }
}