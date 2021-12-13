namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("ProducerInfo")]
public class ProducerInfo
{
    [XmlElement("ProducerRoleCd")]
    public string ProducerRoleCd { get; set; }
}