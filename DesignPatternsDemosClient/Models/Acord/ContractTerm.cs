namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("ContractTerm")]
public class ContractTerm
{
    [XmlElement("EffectiveDt", DataType = "date")]
    public DateTime? EffectiveDt { get; set; }

    [XmlElement("ExpirationDt", DataType = "date")]
    public DateTime? ExpirationDt { get; set; }

    [XmlElement("DurationPeriod")]
    public DurationPeriod DurationPeriod { get; set; }
}