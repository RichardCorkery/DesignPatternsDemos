namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class PolicyRootConverter : IPolicyConverterRule
{
    //ToDo: Rename inputPolicy to acord
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var insuranceSvcRq = inputPolicy.InsuranceSvcRq;

        policy.RequestId = insuranceSvcRq.RqUId;

        policy.PolicyNumber = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber;

        policy.EffectiveDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault();
        policy.ExpirationDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault();

        policy.Term = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.DurationPeriod.NumUnits;

        //ToDo: Review what is the best way to test for null? ?. statement? 
        policy.PrimaryState = insuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo.NameInfo.TaxIdentity.StateProvCd;
        policy.TransactionId = insuranceSvcRq.CommlPkgPolicyAddRq.RqUId;
        policy.TransactionDate = insuranceSvcRq.CommlPkgPolicyAddRq.TransactionRequestDt;
        policy.BroadLobCd = insuranceSvcRq.CommlPkgPolicyAddRq.BroadLobCd;
        policy.PolicyStatusCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyStatusCd;

        policy.SystemSource = $"{inputPolicy.SignonRq.ClientApp.Org}-{inputPolicy.SignonRq.ClientApp.Name}-{inputPolicy.SignonRq.ClientApp.Version}";
        
        policy.LobCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.LobCd;
        policy.NaicCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.NaicCd;
        
        policy.Premium = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt.GetValueOrDefault();
            
        //Demo Note:
        //  - You could have conditional logic
        //  - You could have formating logic

        return policy;
    }
}