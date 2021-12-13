namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class GeneralLiabilityConverterRule : IPolicyConverterRule
{ public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        //Note: Example of self documented code (Clean Code)
        if (acord.HasGeneralLiability()) return policy;
        
        policy.GeneralLiability = new GeneralLiability();

        return policy;
    }
}