namespace DesignPatternsDemosClient.Models.Acord;

//$$$RAC: Review each class and property. Delete what every you think you should
[XmlRoot("ACORD")]
public class Acord
{
    [XmlElement("SignonRq")]
    public SignonRq SignonRq { get; set; }

    [XmlElement("InsuranceSvcRq")]
    public InsuranceSvcRq InsuranceSvcRq { get; set; }

}