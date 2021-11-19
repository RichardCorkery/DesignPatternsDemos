﻿using System.Xml.Linq;
using System.Text.Json;

namespace DesignPatternsDemosClient.Pages
{
    public partial class RulesEngineDemo
    {
        public string AcordPolicy { get; set; }
        public string MyPolicy { get; set; }

        protected override async Task OnInitializedAsync()
        {

            //ToDo pull from xml file?
            try
            {
                var x = "<ACORD xmlns:q1='http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/'><InsuranceSvcRq><RqUID>20ec3051-6bde-47d5-9f5a-c8f485873cb4</RqUID><CommlPkgPolicyAddRq><RqUID>68ed9bec-a667-4deb-9f49-356dc0931d5f</RqUID><ItemIdInfo><SystemId>8109ce6a-812d-4c49-8b42-cbf79d01e7a9</SystemId></ItemIdInfo><TransactionRequestDt>2021-11-02T00:00:00-04:00</TransactionRequestDt><CurCd>USD</CurCd><BroadLOBCd>C</BroadLOBCd><InsuredOrPrincipal><ItemIdInfo><SystemId> 571034 </SystemId></ItemIdInfo><GeneralPartyInfo><NameInfo><CommlName><CommercialName>Richard Corkery</CommercialName>" +
        "</CommlName><LegalEntityCd>IN</LegalEntityCd><TaxIdentity><StateProvCd>PA</StateProvCd></TaxIdentity>" +
  "</NameInfo><Addr><AddrTypeCd>MailingAddress</AddrTypeCd><Addr1>123 Main Street</Addr1><City>Philadelphia</City><StateProvCd>PA</StateProvCd><PostalCode>19111</PostalCode><County>Philadelphia</County><ItemIdInfo><SystemId>9752258</SystemId>" +
       "</ItemIdInfo></Addr></GeneralPartyInfo><InsuredOrPrincipalInfo><InsuredOrPrincipalRoleCd> Insured </InsuredOrPrincipalRoleCd><BusinessInfo><OperationsDesc> BUILDING OWNER - LRO </OperationsDesc></BusinessInfo></InsuredOrPrincipalInfo></InsuredOrPrincipal> " +
    "<CommlPolicy><PolicyNumber>1232221104</PolicyNumber><LOBCd>CPKGE</LOBCd><NAICCd>12345</NAICCd><ContractTerm><EffectiveDt>2021-11-02</EffectiveDt><ExpirationDt>2022-11-02</ExpirationDt></ContractTerm><CurrentTermAmt><Amt>22698</Amt></CurrentTermAmt><MinPremAmt><Amt>1171.05</Amt></MinPremAmt><PolicyStatusCd>NBS</PolicyStatusCd><CommlPolicySupplement /><CommlCoverage><CoverageCd>XTRIA</CoverageCd></CommlCoverage></CommlPolicy><Location id='L1'><ItemIdInfo><AgencyId>1</AgencyId><SystemId>8224025a-0169-4b52-995c-d6c3dc692907</SystemId></ItemIdInfo><Addr><AddrTypeCd>MailingAddress</AddrTypeCd><Addr1>1 Main St</Addr1><City>King Of Prussia</City><PostalCode>19406</PostalCode><StateProvCd>PA</StateProvCd><County>Montgomery</County><ItemIdInfo><SystemId>4304a22c-69e5-4dad-b47a-4ca9ee64c2e8</SystemId></ItemIdInfo></Addr><SubLocation id='L1B1'><ItemIdInfo><SystemId>3e75f3e6-a472-4b00-b746-51889e645715</SystemId></ItemIdInfo><SubLocationName>Bldg 1</SubLocationName></SubLocation><LocationName>Loc 1</LocationName></Location><CommlSubLocation LocationRef='L1' SubLocationRef='L1B1'><Construction><BldgArea><NumUnits>0</NumUnits><UnitMeasurementCd>SQFT</UnitMeasurementCd></BldgArea><ConstructionCd>F</ConstructionCd><YearBuilt>2009</YearBuilt></Construction><BldgProtection><ProtectionClassGradeCd>3</ProtectionClassGradeCd><SprinkleredPct>0</SprinkleredPct></BldgProtection></CommlSubLocation><CommlPropertyLineBusiness><LOBCd>PROPC</LOBCd><NAICCd>12345</NAICCd><CurrentTermAmt><Amt>123456</Amt></CurrentTermAmt><PropertyInfo><CommlPropertyInfo SubLocationRef='L1B1'><OccupancyClassCd xmlns:p7='http://www.w3.org/2001/XMLSchema-instance' p7:nil='true' /><ClassCd>987</ClassCd><CommlCoverage><CurrentTermAmt><Amt>564</Amt></CurrentTermAmt><CoverageCd>BMEBS</CoverageCd></CommlCoverage><CommlCoverage><CurrentTermAmt><Amt>5640</Amt></CurrentTermAmt><CoverageCd>BLDG</CoverageCd><Limit><FormatCurrencyAmt><Amt>1000000</Amt></FormatCurrencyAmt><ValuationCd>ACV</ValuationCd></Limit><Deductible><FormatCurrencyAmt><Amt>1000</Amt></FormatCurrencyAmt><DeductibleAppliesToCd>AllOth</DeductibleAppliesToCd><FormatPct xmlns:p9='http://www.w3.org/2001/XMLSchema-instance' p9:nil='true' /></Deductible><Rate>0.912</Rate><CommlCoverageSupplement><CoverageSubCd>BASIC</CoverageSubCd><CoinsurancePct>80</CoinsurancePct></CommlCoverageSupplement></CommlCoverage><CommlCoverage><CurrentTermAmt><Amt>6150</Amt></CurrentTermAmt><CoverageCd>BPP</CoverageCd><Limit><FormatCurrencyAmt><Amt>1000000</Amt></FormatCurrencyAmt><ValuationCd>ACV</ValuationCd></Limit><Deductible><FormatCurrencyAmt><Amt>1000</Amt></FormatCurrencyAmt><DeductibleAppliesToCd>AllOth</DeductibleAppliesToCd><FormatPct xmlns:p9='http://www.w3.org/2001/XMLSchema-instance' p9:nil='true' /></Deductible><Rate>0.922</Rate><CommlCoverageSupplement><CoverageSubCd>BASIC</CoverageSubCd><CoinsurancePct>80</CoinsurancePct></CommlCoverageSupplement></CommlCoverage><CommlCoverage><CurrentTermAmt><Amt>333</Amt></CurrentTermAmt><CoverageCd>BUSEE</CoverageCd><Limit><FormatCurrencyAmt><Amt>100000</Amt></FormatCurrencyAmt></Limit><Rate>0.777</Rate><CommlCoverageSupplement><CoverageSubCd>BASIC</CoverageSubCd></CommlCoverageSupplement><CommlCoverageSupplement><CoverageSubCd>COINS</CoverageSubCd><CoinsurancePct>80</CoinsurancePct></CommlCoverageSupplement></CommlCoverage></CommlPropertyInfo></PropertyInfo></CommlPropertyLineBusiness><Producer><ItemIdInfo><InsurerId>00000</InsurerId><SystemId>00000000-0000-0000-0000-000000000000</SystemId></ItemIdInfo><GeneralPartyInfo><NameInfo><CommlName /></NameInfo><Addr /></GeneralPartyInfo><ProducerInfo><ProducerRoleCd>Intermediary</ProducerRoleCd></ProducerInfo></Producer></CommlPkgPolicyAddRq></InsuranceSvcRq></ACORD>";

                XDocument doc = XDocument.Parse(x);

                AcordPolicy = doc.ToString();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

        }


        private void Convert()
        {
            //ToDo: Wrap in try / catch
            var policy = _rulesEngineDemoOrchestrator.Process(AcordPolicy);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true; //Pretty print using indent, white space, new line, etc.
            MyPolicy = JsonSerializer.Serialize(policy, options);

        }
    }
}
