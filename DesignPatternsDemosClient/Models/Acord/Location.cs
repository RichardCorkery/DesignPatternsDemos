using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("Location")]
public class Location
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlElement("Addr")]
    public Addr Addr { get; set; }

    [XmlElement("SubLocation")]
    public List<SubLocation> SubLocations { get; set; }

    [XmlElement("LocationName")]
    public string LocationName { get; set; }
}