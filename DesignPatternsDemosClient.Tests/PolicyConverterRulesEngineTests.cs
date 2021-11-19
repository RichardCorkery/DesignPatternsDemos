using Xunit;
using DesignPatternsDemosClient.Services.Minis.RulesEngines;
using System.Collections.Generic;
using DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;
using DesignPatternsDemosClient.Models.Acord;
using System;

namespace DesignPatternsDemosClient.Tests
{
    public class PolicyConverterRulesEngineTests
    {
        private PolicyConverterRulesEngine sut;

        public PolicyConverterRulesEngineTests()
        {
            var policyConverterRules = new List<IPolicyConverterRule>
            {
                new PolicyRootConverter()
            };

            sut = new PolicyConverterRulesEngine(policyConverterRules);
        }

        //ToDo Refactor this Unit test to only test the single rule
        [Fact]
        public void ToPolicy_GivenAnAcordPolicy_AllPolicyRootValuesArePopulatedCorrectly()
        { 
            var acord = new Acord
            {
                InsuranceSvcRq = new InsuranceSvcRq
                {
                    RqUid = new Guid(),
                    CommlPkgPolicyAddRq = new CommlPkgPolicyAddRq
                    {
                        CommlPolicy = new CommlPolicy
                        {   
                            PolicyNumber = "Policy Number",
                            ContractTerm = new ContractTerm()
                            {
                                EffectiveDt = new DateTime(2021, 7, 29),
                                ExpirationDt = new DateTime(2022, 7, 29)
                            },
                            CurrentTermAmt = new CurrentTermAmt()
                            {
                                Amt = 10000
                            }
                        }                        
                    }
                }
            };

            var result = sut.ToPolicy(acord);                       

            Assert.Equal(acord.InsuranceSvcRq.RqUid, result.TransactionId);
            Assert.Equal(acord.InsuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber, result.PolicyNumber);
            Assert.Equal(acord.InsuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt, result.EffectiveDate);
            Assert.Equal(acord.InsuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt, result.ExpirationDate);
            Assert.Equal(acord.InsuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt, result.Premium);
        }

        [Fact]
        public void Convert_GivenAnAcordPolicy_AllPolicyInsuredValuesArePopulatedCorrectly()
        {
            var sut2 = new InsuredConverter();

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
                                }
                            }
                        }
                    }
                }
            };

            var result = sut2.Convert(acord, new Models.Policy.PolicyRoot());

            var generalPartyInfo = acord.InsuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo;

            Assert.Equal(generalPartyInfo.NameInfo.CommlName.CommercialName, result.Insured.FullName);
            Assert.Equal(generalPartyInfo.Addr.Addr1, result.Insured.Address.Line1);
            Assert.Equal(generalPartyInfo.Addr.Addr2, result.Insured.Address.Line2);
            Assert.Equal(generalPartyInfo.Addr.City, result.Insured.Address.City);
            Assert.Equal(generalPartyInfo.Addr.StateProvCd, result.Insured.Address.StateOrProvinceName);
            Assert.Equal(generalPartyInfo.Addr.PostalCode, result.Insured.Address.PostalCode);
            Assert.Equal(generalPartyInfo.Addr.County, result.Insured.Address.RegionName);



        }

    }
}