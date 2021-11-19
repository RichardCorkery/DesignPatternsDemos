using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class InsuredConverter : IPolicyConverterRule
    {
        public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
        {
            var insured = new Insured();

            var generalPartyInfo = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo;

            insured.FullName = generalPartyInfo.NameInfo.CommlName.CommercialName;
            
            insured.Address = new Address
            {
                Line1 = generalPartyInfo.Addr.Addr1,
                Line2 = generalPartyInfo.Addr.Addr2,
                City = generalPartyInfo.Addr.City,
                StateOrProvinceName = generalPartyInfo.Addr.StateProvCd,
                PostalCode = generalPartyInfo.Addr.PostalCode,
                RegionName = generalPartyInfo.Addr.County
            };

            policy.Insured = insured;                       
            
            //Demo Note:
            //  - You could have conditional logic
            //  - You could have formating logic

            return policy;
        }
    }
}