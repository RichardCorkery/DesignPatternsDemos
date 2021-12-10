namespace DesignPatternsDemosClient.Common;

//$$$RAC: Any other constants?
public class DeductibleAppliesCode
{
    public const string BodilyInjury = "BodInj";
    public const string PropertyDamage = "PropDam";
}
public class CoverageCode
{
    public const string GeneralAggregate = "GENAG";
    public const string OccurrenceLimit = "EAOCC";
    public const string ProductsAndCompletedOperations = "PRDCO";
    public const string FireDamage_DamageToRentalPremises = "FIRDM";
    public const string MedicalExpenseLimit = "MEDEX";
    public const string PersonalAndAdvertisingInjuryLiability = "PIADV";

}
public class LimitAppliesCode
{
    public const string Aggregate = "Aggregate";
    public const string PerOccurrence = "PerOcc";
}