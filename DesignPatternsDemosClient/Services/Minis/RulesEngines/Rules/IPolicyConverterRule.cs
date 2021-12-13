//ToDo: ThrowIfNull:
//  - Can this this new feature be used?
//      - If so, where 
//      - Implement

//ToDo: Blazor
//  - Add Error Boundaries
//  - Note these on the ReadMe file?
//  - Page Title

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public interface IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy);
}