using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("CommlPkgPolicyAddRq")]
    public class CommlPkgPolicyAddRq
    {
        //ToDo: Review if this is Acord
        [XmlElement("RqUID")]
        public Guid RqUID { get; set; }

        [XmlElement("CommlPolicy")]
        public CommlPolicy CommlPolicy { get; set; }

        [XmlElement("Location")]
        public List<Location> Locations { get; set; }

        [XmlElement("CommlSubLocation")]
        public List<CommlSubLocation> CommlSubLocations { get; set; }
    }
}