using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("Addr")]
    public class Addr
    {
        [XmlElement("Addr1")]
        public string Addr1 { get; set; }
    }
}