namespace DesignPatternsDemosClient.Tests;

public class PolicyRootConverterTests
{
    [Fact]
    public void Convert_GivenAnAcordPolicy_AllPolicyRootValuesArePopulatedCorrectly()
    {
        var sut = new PolicyRootConverter();

        var acord = new Acord
        {
            SignonRq = new SignonRq()
            {
                ClientApp = new ClientApp()
                {
                    Org = "InsuaSphere"
                }
            },
            InsuranceSvcRq = new InsuranceSvcRq
            {
                RqUId = new Guid(),
                CommlPkgPolicyAddRq = new CommlPkgPolicyAddRq
                {
                    RqUId = new Guid(),
                    TransactionRequestDt = new DateTime(2021, 7, 15),
                    BroadLobCd = "P",
                    CommlPolicy = new CommlPolicy 
                    {   
                        PolicyNumber = "Policy Number",
                        PolicyStatusCd = "NBS",
                        LobCd = "CPKGE",
                        NaicCd = "12345", 
                        ContractTerm = new ContractTerm() 
                        {
                            EffectiveDt = new DateTime(2021, 7, 29),
                            ExpirationDt = new DateTime(2022, 7, 29),
                            DurationPeriod = new DurationPeriod() 
                            {
                                NumUnits = 12
                            }
                        },
                        CurrentTermAmt = new CurrentTermAmt()
                        {
                            Amt = 10000
                        }
                    }, 
                    InsuredOrPrincipal = new InsuredOrPrincipal()
                    {
                        GeneralPartyInfo = new GeneralPartyInfo()
                        {
                            NameInfo = new NameInfo()
                            {
                                TaxIdentity = new TaxIdentity()
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
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.BroadLobCd,policy.BroadLOBCd);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyStatusCd, policy.PolicyStatusCd);

        Assert.Equal(acord.SignonRq.ClientApp.Org, policy.SystemSource);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.LobCd, policy.LOBCd);
        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.NaicCd, policy.NAICCd);

        Assert.Equal(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt, result.Premium);
    }
}