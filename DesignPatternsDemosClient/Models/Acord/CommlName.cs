using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("CommlName")]
public class CommlName 
{
    [XmlElement("CommercialName")]
    public string CommercialName { get; set; }

}