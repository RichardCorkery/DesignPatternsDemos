namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("FormatCurrencyAmt")]
public class FormatCurrencyAmt
{
    [XmlElement("Amt", DataType = "decimal")]
    public decimal? Amt { get; set; }
}