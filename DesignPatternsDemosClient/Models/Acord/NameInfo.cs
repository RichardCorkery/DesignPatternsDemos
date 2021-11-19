using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("NameInfo")]
    public class NameInfo 
    {
        [XmlElement("CommlName")]
        public CommlName CommlName { get; set; }

    }
}
