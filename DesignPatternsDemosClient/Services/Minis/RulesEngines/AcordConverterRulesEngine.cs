using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines
{
    public class AcordConverterRulesEngine: IAcordConverterRulesEngine
    {
        readonly List<IAcordConverterRule> _rules = new List<IAcordConverterRule>();

        public AcordConverterRulesEngine(IEnumerable<IAcordConverterRule> rules)
        {
            _rules.AddRange(rules);
        }

        public string ToAcord(string inputPolicy)
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