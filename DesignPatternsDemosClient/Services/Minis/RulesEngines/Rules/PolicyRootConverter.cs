using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class PolicyRootConverter : IPolicyConverterRule
    {
        public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
        {
            var insuranceSvcRq = inputPolicy.InsuranceSvcRq;

            policy.TransactionId = insuranceSvcRq.RqUid;
            policy.PolicyNumber = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber;
            policy.EffectiveDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault();
            policy.ExpirationDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault();

            //ToDo: Revisit
            //policy.EffectiveDate = DateOnly.FromDateTime(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault() );
            //policy.ExpirationDate = DateOnly.FromDateTime(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault());

            policy.Premium = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt.GetValueOrDefault();
            
            //Demo Note:
            //  - You could have conditional logic
            //  - You could have formating logic

            return policy;
        }
    }
}