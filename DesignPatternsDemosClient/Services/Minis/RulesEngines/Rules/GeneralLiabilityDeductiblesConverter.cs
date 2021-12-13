namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

public class GeneralLiabilityDeductiblesConverter : IPolicyConverterRule
{
    //ToDo: Unit Tests
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        if (policy.GeneralLiability == null) return policy;

        var generalLiabilityDeductible = new GeneralLiabilityDeductible();

        //ToDo: Fix all warning messages
        var propertyDamageDeductible = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness.Deductibles.FirstOrDefault(d => d.DeductibleAppliesToCd == DeductibleAppliesCode.PropertyDamage);
        if (propertyDamageDeductible is not null)
        {
            generalLiabilityDeductible.PropertyDamageDeductibleType = propertyDamageDeductible.DeductibleTypeCd;
            generalLiabilityDeductible.PropertyDamageDeductible = propertyDamageDeductible.FormatInteger.GetValueOrDefault();
        }

        var bodilyInjuryDeductible = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness.Deductibles.FirstOrDefault(d => d.DeductibleAppliesToCd == DeductibleAppliesCode.BodilyInjury);
        if (bodilyInjuryDeductible is not null)
        {
            generalLiabilityDeductible.BodilyInjuryeDeductibleType = bodilyInjuryDeductible.DeductibleTypeCd;
            generalLiabilityDeductible.BodilyInjuryeDeductible = bodilyInjuryDeductible.FormatInteger.GetValueOrDefault();
        }

        policy.GeneralLiability.GeneralLiabilityDeductible = generalLiabilityDeductible;

        return policy;
    }
}