using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Input
{
    public class CompleteOrderInput
    {
        [JsonProperty("personal_photo")]
        public string PersonalPhotoImg { get; set; }

        [JsonProperty("birth_certificate_first_page_image")]
        public string BirthCertificateFirstPageImg { get; set; }

        [JsonProperty("birth_certificate_second_page_image")]
        public string BirthCertificateSecondPageImg { get; set; }

        [JsonProperty("national_card")]
        public string NationalCardImg { get; set; }

        [JsonProperty("national_card_back")]
        public string NationalCardBackImg { get; set; }


        [JsonProperty("insurance_booklet_cver_image")]
        public string InsuranceBookletCoverImg { get; set; }

        [JsonProperty("last_used_page")]
        public string LastUsedPage { get; set; }

        [JsonProperty("in_person_delivery")]
        public bool InPersonDelivery => false;

        [JsonProperty("delivery_time")]
        public OrderDeliveryTimeInput DeliveryTime { get; set; }

        [JsonProperty("delivery_address")]
        public AddressInput DeliveryAddress { get; set; }

        #region Gaurdian
        [JsonProperty("gaurdian_id_card")]
        public string GaurdianIdCard { get; set; }

        [JsonProperty("guardian_family_page")]
        public string GaurdianFamilyPage { get; set; }

        #endregion Gaurdian
    }
}