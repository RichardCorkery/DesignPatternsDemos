using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("ContractTerm")]
    public class ContractTerm
    { 
        //ToDo: Review DateTime?
        [XmlElement("EffectiveDt", DataType = "date")]
        public DateTime? EffectiveDt { get; set; }

        [XmlElement("ExpirationDt", DataType = "date")]
        public DateTime? ExpirationDt { get; set; }
    }
}
