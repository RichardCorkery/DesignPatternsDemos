using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("ACORD")]
    public class Acord
    {

        [XmlElement("InsuranceSvcRq")]
        public InsuranceSvcRq InsuranceSvcRq { get; set; }

    }
}