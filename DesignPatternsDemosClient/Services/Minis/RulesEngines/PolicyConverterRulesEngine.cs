using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines;

public interface IPolicyConverterRulesEngine
{
    public PolicyRoot ToPolicy(Acord acord);
}
public class PolicyConverterRulesEngine: IPolicyConverterRulesEngine
{
    readonly List<IPolicyConverterRule> _rules = new();

    public PolicyConverterRulesEngine(IEnumerable<IPolicyConverterRule> rules)
    {
        _rules.AddRange(rules);
    }

    public PolicyRoot ToPolicy(Acord acord)
    {
        ArgumentNullException.ThrowIfNull(acord);
        
        var policy = new PolicyRoot();

        foreach (var rule in _rules)
        {
            policy = rule.Convert(acord, policy);
        }

        return policy;
    }
}