using System.Collections.Generic;
using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("CommlPkgPolicyAddRq", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class CommlPkgPolicyAddRq
    {
        [XmlElement("Location")]
        public List<Location> Locations { get; set; }

        [XmlElement("CommlSubLocation")]
        public List<CommlSubLocation> CommlSubLocations { get; set; }
    }
}