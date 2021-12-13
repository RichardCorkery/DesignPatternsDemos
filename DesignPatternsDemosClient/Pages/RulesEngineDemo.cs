using System.Xml.Linq;
using System.Text.Json;

namespace DesignPatternsDemosClient.Pages;
public partial class RulesEngineDemo
{
    public string Acord { get; set; } = string.Empty;
    public string Policy { get; set; } = string.Empty;

    public string PageTitlePolicyNumber { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
    public string AlertClass { get; set; } = string.Empty;
    
    protected override async Task OnInitializedAsync()
    {            
        try
        {
            var acordXml = await _httpClient.GetStringAsync("sample-data/acordPolicy.xml");

            var acordXdoc = XDocument.Parse(acordXml);

            Acord = acordXdoc.ToString();
        }
        catch (Exception ex)
        {
            SetMessage("An error occurred while initializing the page", CssClass.AlertDanger);
            Console.WriteLine(ex.Message);
        }
    }

    private void ConvertToPolicy()
    {
        SetMessage(string.Empty, string.Empty);
        Policy = string.Empty;

        try
        {
            var policy = _rulesEngineDemoOrchestrator.Process(Acord);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true //Pretty print using indent, white space, new line, etc.
            };
            Policy = JsonSerializer.Serialize(policy, options);

            PageTitlePolicyNumber = policy.PolicyNumber;
        }
        catch(Exception ex)
        {
            SetMessage("An error occurred while converting the policy", CssClass.AlertDanger);
            Console.WriteLine(ex.Message);
        }
    }

    private void SetMessage(string messageText, string alertClass)
    {
        Message = messageText;
        AlertClass = alertClass;
    }
}