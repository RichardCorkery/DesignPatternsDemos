using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("Addr")]
public class Addr
{
    [XmlElement("Addr1")]
    public string Addr1 { get; set; }

    [XmlElement("Addr2")]
    public string Addr2 { get; set; }

    [XmlElement("Addr3")]
    public string Addr3 { get; set; }

    [XmlElement("City")]
    public string City { get; set; }

    [XmlElement("PostalCode")]
    public string PostalCode { get; set; }

    [XmlElement("StateProvCd")]
    public string StateProvCd { get; set; }

    [XmlElement("County")]
    public string County { get; set; }
        
}