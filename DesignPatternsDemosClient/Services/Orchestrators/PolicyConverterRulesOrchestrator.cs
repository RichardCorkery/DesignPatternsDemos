using DesignPatternsDemosClient.Services.Minis.RulesEngines;

namespace DesignPatternsDemosClient.Services.Orchestrators;
public interface IPolicyConverterRulesOrchestrator
{
    public PolicyRoot Convert(string inputPolicy);
}
public class PolicyConverterRulesOrchestrator: IPolicyConverterRulesOrchestrator
{
    private IPolicyConverterRulesEngine _policyConverterRulesEngine;

    public PolicyConverterRulesOrchestrator(IPolicyConverterRulesEngine policyConverterRulesEngine)
    {
        _policyConverterRulesEngine = policyConverterRulesEngine;
    }
    public PolicyRoot Convert(string inputPolicy)
    {
        ArgumentNullException.ThrowIfNull(inputPolicy);

        var xml = inputPolicy;

        Acord acord = null;

        //ToDo: Move to: Converter or Extension method or reusable converter?

        try
        {

            var x = new XmlSerializer(typeof(Acord));
            using (var sr = new StringReader(xml))
            {

                try
                {
                    acord = x.Deserialize(sr) as Acord;
                }
                catch (Exception ex)
                {
                    var y = ex;
                }
            }
        }
        catch (Exception ex)
        {
            var x = ex.Message;
        }

        return _policyConverterRulesEngine.ToPolicy(acord);
    }
}