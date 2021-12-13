namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("Deductible")]
public class Deductible
{
    [XmlElement("DeductibleAppliesToCd")]
    public string DeductibleAppliesToCd { get; set; }

    [XmlElement("DeductibleTypeCd")]
    public string DeductibleTypeCd { get; set; }
    
    [XmlElement("FormatInteger")]
    public int? FormatInteger { get; set; }
}