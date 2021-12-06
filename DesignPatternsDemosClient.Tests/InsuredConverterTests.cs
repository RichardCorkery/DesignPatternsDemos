namespace DesignPatternsDemosClient.Tests;
public class InsuredConverterTests
{
    [Fact]
    public void Convert_GivenAnAcordPolicy_AllPolicyInsuredValuesArePopulatedCorrectly()
    {
        var sut = new InsuredConverter();

        var acord = new Acord
        {
            InsuranceSvcRq = new InsuranceSvcRq
            {                    
                CommlPkgPolicyAddRq = new CommlPkgPolicyAddRq
                {
                    InsuredOrPrincipal = new InsuredOrPrincipal
                    {
                        GeneralPartyInfo = new GeneralPartyInfo
                        {
                            NameInfo = new NameInfo
                            {
                                CommlName = new CommlName
                                {
                                    CommercialName = "CommericalName"
                                }
                            },
                            Addr = new Addr
                            {
                                Addr1 = "Addr1", 
                                Addr2 = "Addr2", 
                                City = "City",
                                PostalCode = "PostalCode", 
                                County = "County"
                            }, 
                            Communications = new List<Communication>()
                            {
                                new Communication()
                                {
                                    CommunicationUseCd = "Home", 
                                    PhoneNumber = "2155551212",
                                    EmailAddr = "emailaddress@home.com"
                                },
                                new Communication()
                                {
                                    CommunicationUseCd = "Business",
                                    PhoneNumber = "6105553333"
                                }
                            }
                        }
                    }
                }
            }
        };

        var result = sut.Convert(acord, new Models.Policy.PolicyRoot());

        var generalPartyInfo = acord.InsuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo;

        Assert.Equal(generalPartyInfo.NameInfo.CommlName.CommercialName, result.Insured.FullName);

        Assert.Equal(generalPartyInfo.Communications.First(c => c.CommunicationUseCd == "Home").PhoneNumber, result.Insured.PhoneHome);
        Assert.Equal(generalPartyInfo.Communications.First(c => c.CommunicationUseCd == "Home").EmailAddr, result.Insured.EmailAddress);
        Assert.Equal(generalPartyInfo.Communications.First(c => c.CommunicationUseCd == "Business").PhoneNumber, result.Insured.PhoneWork);
        
        Assert.Equal(generalPartyInfo.Addr.Addr1, result.Insured.Address.Line1);
        Assert.Equal(generalPartyInfo.Addr.Addr2, result.Insured.Address.Line2);
        Assert.Equal(generalPartyInfo.Addr.City, result.Insured.Address.City);
        Assert.Equal(generalPartyInfo.Addr.StateProvCd, result.Insured.Address.StateOrProvinceName);
        Assert.Equal(generalPartyInfo.Addr.PostalCode, result.Insured.Address.PostalCode);
        Assert.Equal(generalPartyInfo.Addr.County, result.Insured.Address.RegionName);
    }
}