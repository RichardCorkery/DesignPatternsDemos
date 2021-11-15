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
    }
}