namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class GeneralLiabilityConverter : IPolicyConverterRule
{ public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        if (acord.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness == null) return policy;
        
        policy.GeneralLiability = new GeneralLiability();

        return policy;
    }
}