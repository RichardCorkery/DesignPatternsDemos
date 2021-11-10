using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("CommlPolicy")]
    public class CommlPolicy
    {
        [XmlElement("PolicyNumber")]
        public string PolicyNumber { get; set; }

        [XmlElement("ContractTerm")]
        public ContractTerm ContractTerm { get; set; }

        [XmlElement("CurrentTermAmt")]
        public CurrentTermAmt CurrentTermAmt { get; set; }
    }
}