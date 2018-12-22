using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Output
{
    public class ThirdPartyOfferOutput
    {
        [JsonProperty("solvency_rate")]
        public long? SolvencyRate { get; set; }

        [JsonProperty("indicator")]
        public long Indicator { get; set; }

        [JsonProperty("max_indicator")]
        public long MaxIndicator { get; set; }

        [JsonProperty("min_indicator")]
        public long MinIndicator { get; set; }

        [JsonProperty("installment_tariff")]
        public object InstallmentTariff { get; set; }

        [JsonProperty("installment_tariff_before_tax")]
        public object InstallmentTariffBeforeTax { get; set; }

        [JsonProperty("has_installment_payment")]
        public bool HasInstallmentPayment { get; set; }

        [JsonProperty("installment_payment_rates")]
        public string InstallmentPaymentRates { get; set; }

        [JsonProperty("installment_description")]
        public string InstallmentDescription { get; set; }

        [JsonProperty("base_tariff")]
        public long BaseTariff { get; set; }

        [JsonProperty("min_tariff")]
        public long MinTariff { get; set; }

        [JsonProperty("max_tariff")]
        public long MaxTariff { get; set; }

        [JsonProperty("discount")]
        public long Discount { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }

        [JsonProperty("satisfaction_rate")]
        public string SatisfactionRate { get; set; }

        [JsonProperty("market_share")]
        public long? MarketShare { get; set; }

        [JsonProperty("solvency_level")]
        public long? SolvencyLevel { get; set; }

        [JsonProperty("agents_num")]
        public long? AgentsNum { get; set; }

        [JsonProperty("branches_num")]
        public long? BranchesNum { get; set; }

        [JsonProperty("complaint_over_share_ratio")]
        public long? ComplaintOverShareRatio { get; set; }

        [JsonProperty("company_logo")]
        public string CompanyLogo { get; set; }

        [JsonProperty("discount_amount")]
        public long DiscountAmount { get; set; }

        [JsonProperty("claim_center_num")]
        public long ClaimCenterNum { get; set; }

        [JsonProperty("has_mobile_compensation")]
        public bool HasMobileCompensation { get; set; }

        [JsonProperty("complaint_response_time")]
        public long ComplaintResponseTime { get; set; }

        [JsonProperty("specific_conditions_url")]
        public string SpecificConditionsUrl { get; set; }

        [JsonProperty("faq_url")]
        public string FaqUrl { get; set; }

        [JsonProperty("has_payment_on_delivery")]
        public bool HasPaymentOnDelivery { get; set; }

        [JsonProperty("special_discount_rate")]
        public double SpecialDiscountRate { get; set; }

        [JsonProperty("special_discount")]
        public long SpecialDiscount { get; set; }

        [JsonProperty("has_insurer_promotion")]
        public bool HasInsurerPromotion { get; set; }

        [JsonProperty("insurer_promotion_description")]
        public string InsurerPromotionDescription { get; set; }

        [JsonProperty("delay")]
        public long Delay { get; set; }

        [JsonProperty("delay_penalty")]
        public long DelayPenalty { get; set; }

        [JsonProperty("agency_bimebazar_discount")]
        public long AgencyBimebazarDiscount { get; set; }

        [JsonProperty("cheque_image_required")]
        public bool ChequeImageRequired { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_name_fa")]
        public string CompanyNameFa { get; set; }
    }
}