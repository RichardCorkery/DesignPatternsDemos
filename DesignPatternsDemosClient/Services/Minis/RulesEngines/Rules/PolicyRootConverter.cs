namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class PolicyRootConverter : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        var insuranceSvcRq = acord.InsuranceSvcRq;

        policy.RequestId = insuranceSvcRq.RqUId;

        policy.PolicyNumber = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyNumber;

        policy.EffectiveDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.EffectiveDt.GetValueOrDefault();
        policy.ExpirationDate = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.ExpirationDt.GetValueOrDefault();

        policy.Term = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.ContractTerm.DurationPeriod.NumUnits;

        policy.PrimaryState = insuranceSvcRq.CommlPkgPolicyAddRq.InsuredOrPrincipal.GeneralPartyInfo?.NameInfo.TaxIdentity.StateProvCd;
        policy.TransactionId = insuranceSvcRq.CommlPkgPolicyAddRq.RqUId;
        policy.TransactionDate = insuranceSvcRq.CommlPkgPolicyAddRq.TransactionRequestDt;
        policy.BroadLobCd = insuranceSvcRq.CommlPkgPolicyAddRq.BroadLobCd;
        policy.PolicyStatusCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.PolicyStatusCd;

        policy.SystemSource = $"{acord.SignonRq.ClientApp.Org}-{acord.SignonRq.ClientApp.Name}-{acord.SignonRq.ClientApp.Version}";
        
        policy.LobCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.LobCd;
        policy.NaicCd = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.NaicCd;
        
        policy.Premium = insuranceSvcRq.CommlPkgPolicyAddRq.CommlPolicy.CurrentTermAmt.Amt.GetValueOrDefault();
            
        //Demo Note:
        //  - You could have conditional logic
        //  - You could have formating logic

        return policy;
    }
}