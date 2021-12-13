namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class BuildingConverterRule : IPolicyConverterRule
{
    //Note: This is just here to show more examples of Rules
    public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);
        
        //Here is where I would map the Buildings (Construction Type, Age, etc) to the policy
        
        return policy;
    }
}