namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class Policy1Converter : IPolicyConverterRule
    {
        public string Convert(string inputPolicy, string acordPolicy)
        {
            return acordPolicy;
        }
    }
}