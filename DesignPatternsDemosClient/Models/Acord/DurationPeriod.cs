using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("DurationPeriod")]
    public class DurationPeriod
    {         
        [XmlElement("NumUnits")]
        public int NumUnits { get; set; }

    }
}
