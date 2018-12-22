using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class PreparePayOutput
    {
        //[JsonProperty("tax_cost")]
        //public long TaxCost { get; set; }

        //[JsonProperty("delivery_cost")]
        //public long DeliveryCost { get; set; }

        [JsonProperty("total_price")]
        public long TotalPrice { get; set; }

        //[JsonProperty("paid_amount")]
        //public long PaidAmount { get; set; }

        //[JsonProperty("pre_tax_price")]
        //public long PreTaxPrice { get; set; }

        //[JsonProperty("price")]
        //public long Price { get; set; }

        //[JsonProperty("type")]
        //public string Type { get; set; }

        //[JsonProperty("state")]
        //public long State { get; set; }

        //[JsonProperty("is_paid")]
        //public bool IsPaid { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        //[JsonProperty("tracking_code")]
        //public string TrackingCode { get; set; }
    }
}