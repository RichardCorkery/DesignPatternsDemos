namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class Acord2Converter : IAcordConverterRule
    {
        public string Convert(string inputPolicy, string acordPolicy)
        {
            return acordPolicy;
        }
    }
}