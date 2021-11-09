using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("SubLocation", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class SubLocation
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("SubLocationName")]
        public string SubLocationName { get; set; }

    }
}