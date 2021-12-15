using DesignPatternsDemosClient;
using DesignPatternsDemosClient.Services.Minis.Converters;
using DesignPatternsDemosClient.Services.Minis.RulesEngines;
using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;
using DesignPatternsDemosClient.Services.Orchestrators;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IXmlConverter, XmlConverter>();
builder.Services.AddTransient<IPolicyConverterRulesOrchestrator, PolicyConverterRulesOrchestrator>();

var policyConverterRules = new List<IPolicyConverterRule>
            {
                new PolicyRootConverterRule(), 
                new InsuredConverterRule(), 
                new AgencyConverterRule(),
                new LocationConverter(),
                new BuildingConverterRule(),
                new GeneralLiabilityConverterRule(),
                new GeneralLiabilityLimitsConverterRule(),
                new GeneralLiabilityDeductiblesConverterRule()
            };
builder.Services.AddTransient<IPolicyConverterRulesEngine>(sp => new PolicyConverterRulesEngine(policyConverterRules));

await builder.Build().RunAsync();