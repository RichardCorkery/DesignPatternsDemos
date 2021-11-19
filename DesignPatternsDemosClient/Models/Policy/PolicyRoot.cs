namespace DesignPatternsDemosClient.Models.Policy
{
    public class PolicyRoot
    {
        public Guid TransactionId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        //ToDo: Revisit DateOnly
        //public DateOnly EffectiveDate { get; set; }
        //public DateOnly ExpirationDate { get; set; }
        
        public decimal Premium { get; set; }

        public Insured Insured { get; set; }
    }
}
