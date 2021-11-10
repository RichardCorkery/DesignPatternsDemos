using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines
{    public interface IPolicyConverterRulesEngine
    {
        //ToDo: Method name ToPolicy or ToPolicyModel?
        public string ToPolicy(string inputPolicy);
    }

    public class PolicyConverterRulesEngine: IPolicyConverterRulesEngine
    {
        readonly List<IPolicyConverterRule> _rules = new();

        public PolicyConverterRulesEngine(IEnumerable<IPolicyConverterRule> rules)
        {
            _rules.AddRange(rules);
        }

        public string ToPolicy(string inputPolicy)
        {
            string acordPolicy = string.Empty;

            foreach (var rule in _rules)
            {
                acordPolicy = rule.Convert(inputPolicy, acordPolicy);
            }

            acordPolicy = inputPolicy;
            return acordPolicy;
        }
    }
}