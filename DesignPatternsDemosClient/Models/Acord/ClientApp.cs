namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("ClientApp")]
public class ClientApp
{ 
    [XmlElement("Org")]
    public string Org { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Version")]
    public string Version { get; set; }
}