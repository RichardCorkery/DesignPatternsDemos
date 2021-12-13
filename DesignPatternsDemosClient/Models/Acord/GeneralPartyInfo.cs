namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("GeneralPartyInfo")]
public class GeneralPartyInfo 
{
    [XmlElement("NameInfo")]
    public NameInfo NameInfo { get; set; }

    [XmlElement("Addr")]
    public Addr Addr { get; set; }

    [XmlElement("Communication")]
    public List<Communication> Communications { get; set; }

}