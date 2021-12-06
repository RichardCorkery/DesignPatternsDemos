namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("SignonRq")]
public class SignonRq
{ 
    [XmlElement("ClientApp")]
    public ClientApp ClientApp { get; set; }
}