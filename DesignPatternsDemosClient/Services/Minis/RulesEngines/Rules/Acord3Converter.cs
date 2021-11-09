using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

namespace DesignPatternExamples.Services.Minis.RulesEngines.Rules
{
    public class Acord3Converter : IAcordConverterRule
    {
        public  string Convert(string inputPolicy, string acordPolicy)
        {
            return acordPolicy;
        }
    }
}