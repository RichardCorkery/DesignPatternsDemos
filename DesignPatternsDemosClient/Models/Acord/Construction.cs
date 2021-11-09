using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("Construction", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]

    public class Construction
    {
        //[XmlElement("BldgArea")]
        //public BldgArea BldgArea { get; set; }

        [XmlElement("ConstructionCd")]
        public string ConstructionCd { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("YearBuilt")]
        public int? YearBuilt { get; set; }
    }
}