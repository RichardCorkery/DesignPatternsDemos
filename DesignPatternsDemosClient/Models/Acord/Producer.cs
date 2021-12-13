namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("Producer")]
public class Producer
{
    [XmlElement("ItemIdInfo")]
    public ItemIdInfo ItemIdInfo { get; set; }

    [XmlElement("GeneralPartyInfo")]
    public GeneralPartyInfo GeneralPartyInfo { get; set; }

    [XmlElement("ProducerInfo")]
    public ProducerInfo ProducerInfo { get; set; }
}