namespace DesignPatternsDemosClient.Models.Policy;
public class GeneralLiabilityLimit
{
    //ToDo: nullable?
    public decimal OccurrenceLimit { get; set; }
    public decimal GeneralAggregateLimit { get; set; }
    public decimal ProductsAndCompletedOperationsLimit { get; set; }
    public string DamageToRentalPremisesLimit { get; set; }
    public string MedicalExpenseLimit { get; set; }
    public string PersonalAndAdvertisingInjuryLiabilityLimit { get; set; }
}