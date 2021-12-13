namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class GeneralLiabilityDeductiblesConverterRule : IPolicyConverterRule
{
    public PolicyRoot Convert(Acord acord, PolicyRoot policy)
    {
        ArgumentNullException.ThrowIfNull(acord);
        ArgumentNullException.ThrowIfNull(policy);

        //Note: Example of self documented code (Clean Code)
        if (policy.HasGeneralLiability()) return policy;

        var generalLiabilityDeductible = new GeneralLiabilityDeductible();
        
        var propertyDamageDeductible = acord.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness.Deductibles.FirstOrDefault(d => d.DeductibleAppliesToCd == DeductibleAppliesCode.PropertyDamage);
        if (propertyDamageDeductible is not null)
        {
            generalLiabilityDeductible.PropertyDamageDeductibleType = propertyDamageDeductible.DeductibleTypeCd;
            generalLiabilityDeductible.PropertyDamageDeductible = propertyDamageDeductible.FormatInteger.GetValueOrDefault();
        }

        var bodilyInjuryDeductible = acord.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness.Deductibles.FirstOrDefault(d => d.DeductibleAppliesToCd == DeductibleAppliesCode.BodilyInjury);
        if (bodilyInjuryDeductible is not null)
        {
            generalLiabilityDeductible.BodilyInjuryeDeductibleType = bodilyInjuryDeductible.DeductibleTypeCd;
            generalLiabilityDeductible.BodilyInjuryeDeductible = bodilyInjuryDeductible.FormatInteger.GetValueOrDefault();
        }

        policy.GeneralLiability.GeneralLiabilityDeductible = generalLiabilityDeductible;

        return policy;
    }
}