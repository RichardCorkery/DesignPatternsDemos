namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class GeneralLiabilityConverter : IPolicyConverterRule
{ public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        if (inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness == null) return policy;
        
        policy.GeneralLiability = new GeneralLiability();

        return policy;
    }
}