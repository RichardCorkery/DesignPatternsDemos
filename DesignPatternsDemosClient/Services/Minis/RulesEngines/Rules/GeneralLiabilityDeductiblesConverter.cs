namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;
public class GeneralLiabilityDeductiblesConverter : IPolicyConverterRule
{
    //$$$RAC: Unit Tests
    public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var generalLiabilityDeductible = new GeneralLiabilityDeductible();

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

        policy.GeneralLiability ??= new GeneralLiability();

        policy.GeneralLiability.GeneralLiabilityDeductible = generalLiabilityDeductible;

        return policy;
    }
}