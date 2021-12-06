namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("TaxIdentity")]
public class TaxIdentity
{
    [XmlElement("StateProvCd")]
    public string StateProvCd { get; set; }
}