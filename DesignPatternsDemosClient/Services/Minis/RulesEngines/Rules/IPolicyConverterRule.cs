using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

//ToDo: Fix Namespaces
namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public interface IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy);
}