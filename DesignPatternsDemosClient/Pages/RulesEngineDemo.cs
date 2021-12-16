using System.Xml.Linq;
using System.Text.Json;
using DesignPatternsDemosClient.Services.Orchestrators;
using Microsoft.AspNetCore.Components;

namespace DesignPatternsDemosClient.Pages;
public partial class RulesEngineDemo
{
    [Inject]
    public HttpClient HttpClient{ get; set; }

    [Inject]
    public IPolicyConverterRulesOrchestrator PolicyConverterRulesOrchestrator { get; set; }

    public string AcordXml { get; set; } = string.Empty;

    public string PolicyJson { get; set; } = string.Empty;

    public string PageTitlePolicyNumber { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
    public string AlertClass { get; set; } = string.Empty;
    
    protected override async Task OnInitializedAsync()
    {            
        try
        {
            var acordXml = await HttpClient.GetStringAsync("sample-data/acordPolicyV1.xml");

            var acordXdoc = XDocument.Parse(acordXml);

            AcordXml = acordXdoc.ToString();
        }
        catch (Exception ex)
        {
            SetMessage("An error occurred while initializing the page", CssClass.AlertDanger);
            //ToDo: Add Logging.  Might be a little too much since this is just a demo and a Blazor Wasm
            //      Maybe create stand alone demo for this concept
            Console.WriteLine(ex.Message);
        }
    }

    private void ConvertToPolicy()
    {
        SetMessage(string.Empty, string.Empty);
        PolicyJson = string.Empty;

        try
        {
            var policy = PolicyConverterRulesOrchestrator.Convert(AcordXml);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true //Pretty print using indent, white space, new line, etc.
            };
            PolicyJson = JsonSerializer.Serialize(policy, options);

            PageTitlePolicyNumber = policy.PolicyNumber;
        }
        catch(Exception ex)
        {
            SetMessage("An error occurred while converting the policy", CssClass.AlertDanger);
            Console.WriteLine(ex.Message);
        }
    }

    //ToDo: Make the Message a Component
    //      If so, can I use Error Boundry
    private void SetMessage(string messageText, string alertClass)
    {
        Message = messageText;
        AlertClass = alertClass;
    }
}