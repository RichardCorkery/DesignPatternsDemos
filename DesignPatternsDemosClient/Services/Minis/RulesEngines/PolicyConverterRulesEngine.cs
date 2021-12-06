using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines;

public interface IPolicyConverterRulesEngine
{
    //ToDo: Method name ToPolicy or ToPolicyModel?
    public PolicyRoot ToPolicy(Acord inputPolicy);
}

public class PolicyConverterRulesEngine: IPolicyConverterRulesEngine
{
    readonly List<IPolicyConverterRule> _rules = new();

    public PolicyConverterRulesEngine(IEnumerable<IPolicyConverterRule> rules)
    {
        _rules.AddRange(rules);
    }

    public PolicyRoot ToPolicy(Acord inputPolicy)
    {
        var policy = new PolicyRoot();

        foreach (var rule in _rules)
        {
            policy = rule.Convert(inputPolicy, policy);
        }

        return policy;
    }
}