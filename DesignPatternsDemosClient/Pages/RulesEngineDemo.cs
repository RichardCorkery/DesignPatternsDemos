using System.Xml.Linq;
using System.Text.Json;

namespace DesignPatternsDemosClient.Pages;
public partial class RulesEngineDemo
{
    public string AcordPolicy { get; set; }
    public string MyPolicy { get; set; }

    protected override async Task OnInitializedAsync()
    {            
        try
        {

            var acordXml = await _httpClient.GetStringAsync("sample-data/acordPolicy.xml");

            var acordXdoc = XDocument.Parse(acordXml);

            AcordPolicy = acordXdoc.ToString();
        }
        catch (Exception ex)
        {
            //ToDo Add basic logging
            var x = ex.Message;
        }

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