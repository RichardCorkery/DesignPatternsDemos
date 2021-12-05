using System.Xml.Linq;
using System.Text.Json;
using DesignPatternsDemosClient.Models.Acord;

namespace DesignPatternsDemosClient.Pages
{
    public partial class RulesEngineDemo
    {
        public string AcordPolicy { get; set; }
        public string MyPolicy { get; set; }

        protected override async Task OnInitializedAsync()
        {            
            try
            {

                var acordXml = await Http.GetStringAsync("sample-data/acordPolicy.xml");

                var acordXdoc = XDocument.Parse(acordXml);

                AcordPolicy = acordXdoc.ToString();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public string? Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }


        private void Convert()
        {

            try
            {
                var policy = _rulesEngineDemoOrchestrator.Process(AcordPolicy);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true; //Pretty print using indent, white space, new line, etc.
                MyPolicy = JsonSerializer.Serialize(policy, options);
            }
            catch(Exception ex)
            {
                //ToDo: What do you want to do here?
                var x = ex.Message;
            }
        }
    }
}
