using DesignPatternsDemosClient;
using DesignPatternExamples.Services.Minis.RulesEngines.Rules;
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

var acordConverterRules = new List<IAcordConverterRule>
            {
                new Acord5Converter(),
                new Acord4Converter(),
                new Acord2Converter(),
                new Acord1Converter(),
                new Acord3Converter()
            };
builder.Services.AddTransient<IAcordConverterRulesEngine>(sp => new AcordConverterRulesEngine(acordConverterRules));

await builder.Build().RunAsync();
