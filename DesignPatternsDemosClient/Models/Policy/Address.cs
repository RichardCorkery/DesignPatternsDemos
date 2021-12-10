namespace DesignPatternsDemosClient.Models.Policy;

//$$$RAC: Review each class and property.
//Nullable?  
public class Address
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string StateOrProvinceName { get; set; }
    public string PostalCode { get; set; }
    public string RegionName { get; set; }
}