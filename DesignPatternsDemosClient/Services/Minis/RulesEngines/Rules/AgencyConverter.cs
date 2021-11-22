using DesignPatternsDemosClient.Models.Acord;
using DesignPatternsDemosClient.Models.Policy;

namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules
{
    public class AgencyConverter : IPolicyConverterRule
    {
        public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
        {
            //ToDo: Set up: 
            //  - Global using statements
            //  - File-scoped Namespaces

            //To Do: Blazor
            //  - Add Error Bondries
            //  - Note these on the ReadMe file?
            //  - Page Title

            return policy;
        }
    }
}