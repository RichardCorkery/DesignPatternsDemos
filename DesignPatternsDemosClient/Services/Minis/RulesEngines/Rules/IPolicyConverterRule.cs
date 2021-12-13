//ToDo: Blazor
//  - Add Error Boundaries

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public interface IPolicyConverterRule
{
    public PolicyRoot Convert(Acord acord, PolicyRoot policy);
}