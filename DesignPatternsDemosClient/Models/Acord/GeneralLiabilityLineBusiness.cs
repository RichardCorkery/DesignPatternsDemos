namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("GeneralLiabilityLineBusiness")]
public class GeneralLiabilityLineBusiness
{
    [XmlElement("Deductible")]
    public List<Deductible>? Deductibles { get; set; }

    [XmlElement("LiabilityInfo")]
    public LiabilityInfo? LiabilityInfo { get; set; }
}