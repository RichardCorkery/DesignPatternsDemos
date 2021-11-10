using System.Xml.Serialization;
using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Services.Minis.RulesEngines;

namespace DesignPatternsDemosClient.Services.Orchestrators
{
    public interface IRulesEngineDemoOrchestrator
    {
        //ToDo: Better method name
        public string Process(string inputPolicy);
    }
    public class RulesEngineDemoOrchestrator: IRulesEngineDemoOrchestrator
    {
        private IPolicyConverterRulesEngine _acordConverterRulesEngine;

        public RulesEngineDemoOrchestrator(IPolicyConverterRulesEngine acordConverterRulesEngine)
        {
            _acordConverterRulesEngine = acordConverterRulesEngine;
        }
        public string Process(string inputPolicy)
        {
            var xml = inputPolicy;

            Acord a = null;

            //Converter or Extension method or reusable converter?

                var x = new XmlSerializer(typeof(Acord));
                using (var sr = new StringReader(xml))
                {

                    try
                    {
                        a = x.Deserialize(sr) as Acord;
                    }
                    catch (Exception ex)
                    {
                        var y = ex;
                    }
                }

                return _acordConverterRulesEngine.ToPolicy(inputPolicy);
        }
    }
}