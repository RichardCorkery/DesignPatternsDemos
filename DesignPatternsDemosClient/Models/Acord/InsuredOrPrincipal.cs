using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("InsuredOrPrincipal")]
    public class InsuredOrPrincipal
    {        
        [XmlElement("GeneralPartyInfo")]
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
        
    }
}
