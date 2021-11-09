namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public interface IAcordConverterRule
    {
        public string Convert(string inputPolicy, string acordPolicy);
    }
}