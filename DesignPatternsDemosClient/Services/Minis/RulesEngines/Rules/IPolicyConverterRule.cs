using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public interface IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy);
}