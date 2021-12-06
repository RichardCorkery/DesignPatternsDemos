namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("ItemIdInfo")]
public class ItemIdInfo
{
    [XmlElement("AgencyId")]
    public string AgencyId { get; set; }
}