namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

//Note: This is just here to show more examples of Rules
public class LocationConverter : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        //Here is where I would map the Locations (address and etc) to the policy

        return policy;
    }
}