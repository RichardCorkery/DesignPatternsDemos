using DesignPatternsDemosClient.Services.Minis.RulesEngines;

//$$$RAC: Review
namespace DesignPatternsDemosClient.Services.Orchestrators;
public interface IRulesEngineDemoOrchestrator
{
    //ToDo: Better method name
    public PolicyRoot Process(string inputPolicy);
}
public class RulesEngineDemoOrchestrator: IRulesEngineDemoOrchestrator
{
    private IPolicyConverterRulesEngine _acordConverterRulesEngine;

    public RulesEngineDemoOrchestrator(IPolicyConverterRulesEngine acordConverterRulesEngine)
    {
        _acordConverterRulesEngine = acordConverterRulesEngine;
    }
    public PolicyRoot Process(string inputPolicy)
    {
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

        return _acordConverterRulesEngine.ToPolicy(acord);
    }
}