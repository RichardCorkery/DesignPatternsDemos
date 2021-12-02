using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

//ToDo: Set up: 
//  - Global using statements
//  - File-scoped Namespaces

//ToDo: ThrowIfNull:
//  - Can this this new feature be used?
//      - If so, where 
//      - Implement

//ToDo: Blazor
//  - Add Error Boundaries
//  - Note these on the ReadMe file?
//  - Page Title

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class AgencyConverter : IPolicyConverterRule
    {
        
        public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
        {
            var agency = new Agency();

            //Note: There are many more fields that could be mapped for Agency including: Name, Address, Company Information and etc
            agency.Id = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.Producer.ItemIdInfo.AgencyId;

            policy.Agency = agency;

            return policy;
        }
    }
}