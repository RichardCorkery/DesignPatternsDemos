using DesignPatternsDemosClient;
using DesignPatternsDemosClient.Services.Minis.RulesEngines;
using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;
using DesignPatternsDemosClient.Services.Orchestrators;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IRulesEngineDemoOrchestrator, RulesEngineDemoOrchestrator>();

var acordConverterRules = new List<IPolicyConverterRule>
            {
                new PolicyRootConverter()
            };
builder.Services.AddTransient<IPolicyConverterRulesEngine>(sp => new PolicyConverterRulesEngine(acordConverterRules));

await builder.Build().RunAsync();