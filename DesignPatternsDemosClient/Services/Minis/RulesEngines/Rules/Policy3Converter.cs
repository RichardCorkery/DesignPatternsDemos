using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternExamples.Services.Minis.RulesEngines.Rules
{
    public class Policy3Converter : IPolicyConverterRule
    {
        public  string Convert(string inputPolicy, string acordPolicy)
        {
            return acordPolicy;
        }
    }
}