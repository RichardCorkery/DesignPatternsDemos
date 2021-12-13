namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class AgencyConverter : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var agency = new Agency();

        //Note: There are many more fields that could be mapped for Agency including: Id, Address, Company Information and etc
        agency.Name = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.Producer.GeneralPartyInfo.NameInfo.CommlName.CommercialName;

        policy.Agency = agency;

        return policy;
    }
}