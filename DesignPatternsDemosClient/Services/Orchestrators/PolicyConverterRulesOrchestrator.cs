using DesignPatternsDemosClient.Services.Minis.Converters;
using DesignPatternsDemosClient.Services.Minis.RulesEngines;

namespace DesignPatternsDemosClient.Services.Orchestrators;
public interface IPolicyConverterRulesOrchestrator
{
    public PolicyRoot Convert(string inputPolicy);
}
public class PolicyConverterRulesOrchestrator: IPolicyConverterRulesOrchestrator
{
    private readonly IXmlConverter _xmlConverter;
    private readonly IPolicyConverterRulesEngine _policyConverterRulesEngine;

    public PolicyConverterRulesOrchestrator(IXmlConverter xmlConverter, IPolicyConverterRulesEngine policyConverterRulesEngine)
    {
        _xmlConverter = xmlConverter;
        _policyConverterRulesEngine = policyConverterRulesEngine;
    }

    public PolicyRoot Convert(string acordXml)
    {
        ArgumentNullException.ThrowIfNull(acordXml);

        var acord = _xmlConverter.ToObject<Acord>(acordXml);
        return _policyConverterRulesEngine.ToPolicy(acord);
    }
}