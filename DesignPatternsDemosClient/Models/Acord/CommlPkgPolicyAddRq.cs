namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("CommlPkgPolicyAddRq")]
public class CommlPkgPolicyAddRq
{
    [XmlElement("RqUID")]
    public Guid RqUId { get; set; }

    [XmlElement("TransactionRequestDt")]
    public DateTime TransactionRequestDt { get; set; }
        
    [XmlElement("BroadLOBCd")]
    public string BroadLobCd { get; set; }

    [XmlElement("InsuredOrPrincipal")]
    public InsuredOrPrincipal InsuredOrPrincipal { get; set; }

    [XmlElement("Producer")]
    public Producer Producer { get; set; }

    [XmlElement("CommlPolicy")]
    public CommlPolicy CommlPolicy { get; set; }

    [XmlElement("Location")]
    public List<Location> Locations { get; set; }

    [XmlElement("CommlSubLocation")]
    public List<CommlSubLocation> CommlSubLocations { get; set; }

    [XmlElement("GeneralLiabilityLineBusiness")]
    public GeneralLiabilityLineBusiness? GeneralLiabilityLineBusiness { get; set; }
}