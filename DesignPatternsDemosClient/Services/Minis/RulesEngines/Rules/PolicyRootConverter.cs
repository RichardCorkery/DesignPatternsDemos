namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class PolicyRootConverter : IPolicyConverterRule
{
    //$$$RAC: Rename inputPolicy to acord
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var insuranceSvcRq = inputPolicy.InsuranceSvcRq;

        policy.RequestId = insuranceSvcRq.RqUId;

        policy.PolicyNumber = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber;
            
        //ToDo: Does ACORD have a Description?
        //policy.Description = insuranceSvcRq.

        policy.EffectiveDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault();
        policy.ExpirationDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault();

        //ToDo: Revisit
        //policy.EffectiveDate = DateOnly.FromDateTime(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault() );
        //policy.ExpirationDate = DateOnly.FromDateTime(insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault());

        policy.Term = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.DurationPeriod.NumUnits;

        //ToDo: Review what is the best way to test for null? ?. statement? 
        policy.PrimaryState = insuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo.NameInfo.TaxIdentity.StateProvCd;
        policy.TransactionId = insuranceSvcRq.CommlPkgPolicyAddRq.RqUId;
        policy.TransactionDate = insuranceSvcRq.CommlPkgPolicyAddRq.TransactionRequestDt;
        policy.BroadLOBCd = insuranceSvcRq.CommlPkgPolicyAddRq.BroadLobCd;
        policy.PolicyStatusCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyStatusCd;

        policy.SystemSource = inputPolicy.SignonRq.ClientApp.Org; //+name + ver
           

        policy.LOBCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.LobCd;
        policy.NAICCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.NaicCd;


        policy.Premium = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt.GetValueOrDefault();
            
        //Demo Note:
        //  - You could have conditional logic
        //  - You could have formating logic

        return policy;
    }
}