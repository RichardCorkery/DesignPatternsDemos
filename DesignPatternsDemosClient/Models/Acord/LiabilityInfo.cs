namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("LiabilityInfo")]
public class LiabilityInfo
{
    [XmlElement("CommlCoverage")]
    public List<CommlCoverage> CommlCoverage { get; set; }
}