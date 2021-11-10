using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("CommlSubLocation")]
    public class CommlSubLocation
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("LocationRef")]
        public string LocationRef { get; set; }

        [XmlAttribute("SubLocationRef")]
        public string SubLocationRef { get; set; }

        [XmlElement("Construction")]
        public Construction Construction { get; set; }
    }
}