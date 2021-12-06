namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("CurrentTermAmt")]
public class CurrentTermAmt
{
    [XmlElement("Amt")]
    public decimal? Amt { get; set; }
}