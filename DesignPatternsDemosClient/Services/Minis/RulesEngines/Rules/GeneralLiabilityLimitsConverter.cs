﻿namespace DesignPatternsDemosClient.Services.Minis.RulesEngines.Rules;

//$$$RAC: Unit Tests
public class GeneralLiabilityLimitsConverter : IPolicyConverterRule
{ public PolicyRoot Convert(Acord inputPolicy, PolicyRoot policy)
    {
        var generalLiabilityLimit = new GeneralLiabilityLimit();

        var liabilityInfo = inputPolicy.InsuranceSvcRq.CommlPkgPolicyAddRq.GeneralLiabilityLineBusiness.LiabilityInfo;
        
        generalLiabilityLimit.OccurrenceLimit = liabilityInfo.GetCoverageValue(CoverageCode.OccurrenceLimit, LimitAppliesCode.PerOccurrence, 0);
        generalLiabilityLimit.GeneralAggregateLimit = liabilityInfo.GetCoverageValue(CoverageCode.GeneralAggregate, LimitAppliesCode.Aggregate, 0);
        generalLiabilityLimit.ProductsAndCompletedOperationsLimit = liabilityInfo.GetCoverageValue(CoverageCode.ProductsAndCompletedOperations, LimitAppliesCode.PerOccurrence, 0);
        
        generalLiabilityLimit.DamageToRentalPremisesLimit = liabilityInfo.GetLimitValue(CoverageCode.FireDamage_DamageToRentalPremises);
        generalLiabilityLimit.MedicalExpenseLimit = liabilityInfo.GetLimitValue(CoverageCode.MedicalExpenseLimit);
        generalLiabilityLimit.PersonalAndAdvertisingInjuryLiabilityLimit = liabilityInfo.GetLimitValue(CoverageCode.PersonalAndAdvertisingInjuryLiability);
        
        policy.GeneralLiability ??= new GeneralLiability();

        policy.GeneralLiability.GeneralLiabilityLimit = generalLiabilityLimit;

        return policy;
    }
}