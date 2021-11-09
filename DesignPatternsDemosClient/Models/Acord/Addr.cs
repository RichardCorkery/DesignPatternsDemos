using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("Addr", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class Addr
    {
        [XmlElement("Addr1")]
        public string Addr1 { get; set; }
    }
}