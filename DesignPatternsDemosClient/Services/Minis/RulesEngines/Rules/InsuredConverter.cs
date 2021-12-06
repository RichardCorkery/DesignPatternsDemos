namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class InsuredConverter : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var insured = new Insured();

        var generalPartyInfo = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo;

        insured.FullName = generalPartyInfo.NameInfo.CommlName.CommercialName;

        //ToDo: What if anything this null?
        //insured.PhoneHome = generalPartyInfo.Communications.FirstOrDefault(c => c.CommunicationUseCd == "Business").PhoneNumber
        //insured.PhoneWork = generalPartyInfo.Communications.FirstOrDefault(c => c.CommunicationUseCd == "Home").PhoneNumber
        //insured.EmailAddress = generalPartyInfo.Communications.FirstOrDefault(c => c.CommunicationUseCd == "Home").EmailAddr
        
        //Note: To conform with the Single Responsibility Principle I would normally move the Address processing to it's own rule 
        insured.Address = new Address
        {
            Line1 = generalPartyInfo.Addr.Addr1,
            Line2 = generalPartyInfo.Addr.Addr2,
            City = generalPartyInfo.Addr.City,
            StateOrProvinceName = generalPartyInfo.Addr.StateProvCd,
            PostalCode = generalPartyInfo.Addr.PostalCode,
            RegionName = generalPartyInfo.Addr.County
        };

        policy.Insured = insured;                       
            
        //Demo Note:
        //  - You could have conditional logic
        //  - You could have formating logic

        return policy;
    }
}