namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public interface IPolicyConverterRule
    {
        public string Convert(string inputPolicy, string acordPolicy);
    }
}