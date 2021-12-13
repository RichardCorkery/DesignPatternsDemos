namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("Limit")]
public class Limit
{
    [XmlElement("LimitAppliesToCd")]
    public string LimitAppliesToCd { get; set; }

    [XmlElement("FormatCurrencyAmt")]
    public FormatCurrencyAmt FormatCurrencyAmt { get; set; }
}