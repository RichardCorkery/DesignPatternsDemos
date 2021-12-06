namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("SubLocation")]
public class SubLocation
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlElement("SubLocationName")]
    public string SubLocationName { get; set; }

}