using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RobokaBimeBazar.Domain.Enum;

namespace RobokaBimeBazar.API.Json.Input
{
    public class CreateOrderInput
    {
        [JsonProperty("policy_holder")]
        public PolicyHolderInput PolicyHolder { get; set; }

        [JsonProperty("company")]
        public CompanyInput Company { get; set; }

        [JsonProperty("policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty("social_security_branch")]
        public string SocialSecurityBranch { get; set; }

        public InsuredStatusEnum InsuredStatusEnum { get; set; }

        [JsonProperty("insured_status")]
        public string InsuredStatus => InsuredStatusEnum == InsuredStatusEnum.PolicyHolder ? "policy_holder" : "under_custody";

        public SocialSecurityServiceTypeEnum SocialSecurityServiceType { get; set; }

        [JsonProperty("social_security_service_type")]
        public string SocialSecurityServiceTypeString => (SocialSecurityServiceType == SocialSecurityServiceTypeEnum.Extend) ?
            "extend" : (SocialSecurityServiceType == SocialSecurityServiceTypeEnum.New) ? "new" : "renew";

        #region gaurdian 
        [JsonProperty("guardian_birth_date")]
        public string GaurdianBirthDate { get; set; }

        [JsonProperty("guardian_dependency_type")]
        public string GaurdianDependencyType => (GaurdianDependencyTypeAsEnum == GaurdianDependencyTypeEnum.Child) ?
            "child" : (GaurdianDependencyTypeAsEnum == GaurdianDependencyTypeEnum.Father) ?
            "father" : (GaurdianDependencyTypeAsEnum == GaurdianDependencyTypeEnum.Mother) ?
            "mother" : (GaurdianDependencyTypeAsEnum == GaurdianDependencyTypeEnum.Spouse) ? "spouse" : "";

        public GaurdianDependencyTypeEnum? GaurdianDependencyTypeAsEnum { get; set; }

        [JsonProperty("guardian_national_id")]
        public string GaurdianNationalId { get; set; }

        [JsonProperty("guardian_policy_id")]
        public string GaurdianPolicyId { get; set; }

        [JsonProperty("guardian_social_security_branch")]
        public string GaurdianSocialSecurityBranchId { get; set; }

        [JsonProperty("guardian_status")]
        public string GaurdianStatus => GaurdianStatusAsEnum == GaurdianStatusEnum.Employed ? "employed" : "retired";

        public GaurdianStatusEnum GaurdianStatusAsEnum { get; set; }

        public SpouseLifeStatusEnum? SpouseLifeStatusAsEnum { get; set; }

        [JsonProperty("spouse_life_status")]
        public string SpouseLifeStatus => (GaurdianDependencyTypeAsEnum != GaurdianDependencyTypeEnum.Spouse) ? "" :
            (SpouseLifeStatusAsEnum == SpouseLifeStatusEnum.Alive) ? "alive" : "dead";
        #endregion
    }

}
