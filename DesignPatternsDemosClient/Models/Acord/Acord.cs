namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("ACORD")]
public class Acord
{
    [XmlElement("SignonRq")]
    public SignonRq SignonRq { get; set; }

    [XmlElement("InsuranceSvcRq")]
    public InsuranceSvcRq InsuranceSvcRq { get; set; }

}