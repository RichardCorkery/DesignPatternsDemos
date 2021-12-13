namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class InsuredConverter : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var generalPartyInfo = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo;
        
        if(generalPartyInfo is null) return policy;

        var insured = new Insured();

        insured.FullName = generalPartyInfo.NameInfo.CommlName.CommercialName;

        var communication = generalPartyInfo.Communications.FirstOrDefault(c => c.CommunicationUseCd == CommunicationUseCode.Home);
        if (communication != null)
        {
            insured.PhoneHome = communication.PhoneNumber;
            insured.EmailAddress = communication.EmailAddr;
        }

        communication = generalPartyInfo.Communications.FirstOrDefault(c => c.CommunicationUseCd == CommunicationUseCode.Business);
        if (communication != null)
        {
            insured.PhoneWork = communication.PhoneNumber;
        }

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