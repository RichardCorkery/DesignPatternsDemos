using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("CommlPkgPolicyAddRq")]
    public class CommlPkgPolicyAddRq
    {
        //ToDo: Review if this is Acord
        [XmlElement("RqUID")]
        public Guid RqUID { get; set; }

        //ToDo: Implement Date Only
        [XmlElement("TransactionRequestDt")]
        public DateTime TransactionRequestDt { get; set; }

        //ToDo Make sure all properties follow my naming standards
        [XmlElement("BroadLOBCd")]
        public string BroadLOBCd { get; set; }

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



    }
}