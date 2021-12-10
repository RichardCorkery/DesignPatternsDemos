namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("CommlCoverage")]
public class CommlCoverage
{
    [XmlElement("CoverageCd")]
    public string CoverageCd { get; set; }

    [XmlElement("Limit")]
    public List<Limit> Limits { get; set; }
}