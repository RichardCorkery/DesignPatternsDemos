namespace DesignPatternsDemosClient.Models.Acord;

public class Communication
{
    [XmlElement("CommunicationUseCd")]
    public string CommunicationUseCd { get; set; }

    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [XmlElement("EmailAddr")]
    public string EmailAddr { get; set; }
}