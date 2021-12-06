namespace DesignPatternsDemosClient.Models.Policy;

public class PolicyRoot
{
        
    public Guid RequestId { get; set; }
        
    public string PolicyNumber { get; set; }

    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    //ToDo: Revisit DateOnly
    //public DateOnly EffectiveDate { get; set; }
    //public DateOnly ExpirationDate { get; set; }

    public int Term { get; set; }

    public string PrimaryState { get; set; }

    public Guid TransactionId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string PolicyStatusCd { get; set; }

    //Add attribute
    public string LOBCd { get; set; }

    //Add attribute
    public string NAICCd { get; set; }

    public string BroadLOBCd { get; set; }

    public string AgencyCode { get; set; }

    public string SystemSource { get; set; }

    public decimal Premium { get; set; }

    public Insured Insured { get; set; }        
             
    public Agency Agency { get; set; }
}