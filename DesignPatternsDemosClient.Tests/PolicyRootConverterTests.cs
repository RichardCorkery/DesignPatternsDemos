namespace DesignPatternsDemosClient.Tests;

public class PolicyRootConverterTests
{
    [Fact]
    public void Convert_GivenAnAcordPolicy_AllPolicyRootValuesArePopulatedCorrectly()
    {
        var sut = new PolicyRootConverterRule();

        var acord = new Acord
        {
            SignonRq = new()
            {
                ClientApp = new()
                {
                    Org = "InsuaSphere", 
                    Name =  "Policy Importer", 
                    Version = "1.1"
                }
            },
            InsuranceSvcRq = new ()
            {
                RqUId = new (),
                CommlPkgPolicyAddRq = new()
                {
                    RqUId = new Guid(),
                    TransactionRequestDt = new (2021, 7, 15),
                    BroadLobCd = "P",
                    CommlPolicy = new() 
                    {   
                        PolicyNumber = "Policy Number",
                        PolicyStatusCd = "NBS",
                        LobCd = "CPKGE",
                        NaicCd = "12345", 
                        ContractTerm = new() 
                        {
                            EffectiveDt = new (2021, 7, 29),
                            ExpirationDt = new (2022, 7, 29),
                            DurationPeriod = new() 
                            {
                                NumUnits = 12
                            }
                        },
                        CurrentTermAmt = new()
                        {
                            Amt = 10000
                        }
                    }, 
                    InsuredOrPrincipal = new()
                    {
                        GeneralPartyInfo = new()
                        {
                            NameInfo = new()
                            {
                                TaxIdentity = new()
                                {
                                    StateProvCd = "PA"
                                }
                            }
                        }
                    }
                }
            }
        };

        var policy = new PolicyRoot();

        var result = sut.Convert(acord, policy);

        var insuranceSvcRq = acord.InsuranceSvcRq;

        Assert.Equal(insuranceSvcRq.RqUId, result.TransactionId);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber, result.PolicyNumber);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt, result.EffectiveDate);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt, result.ExpirationDate);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.DurationPeriod.NumUnits, result.Term);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo.NameInfo.TaxIdentity.StateProvCd,policy.PrimaryState );
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.RqUId,policy.TransactionId);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.TransactionRequestDt,policy.TransactionDate);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.BroadLobCd,policy.BroadLobCd);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyStatusCd, policy.PolicyStatusCd);

        Assert.Equal("InsuaSphere-Policy Importer-1.1", policy.SystemSource);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.LobCd, policy.LobCd);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.NaicCd, policy.NaicCd);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt, result.Premium);
    }
}