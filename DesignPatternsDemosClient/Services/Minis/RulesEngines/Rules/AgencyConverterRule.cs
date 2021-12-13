namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class AgencyConverterRule : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        //ToDo: Create a Base Class and put these checks there (Decorator Design Pattern?)
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        var agency = new Agency();

        //Note: There are many more fields that could be mapped for Agency including: Id, Address, Company Information and etc
        agency.Name = acord.InsuranceSvcRq.CommlPkgPolicyAddRq.Producer.GeneralPartyInfo.NameInfo.CommlName.CommercialName;

        policy.Agency = agency;

        return policy;
    }
}