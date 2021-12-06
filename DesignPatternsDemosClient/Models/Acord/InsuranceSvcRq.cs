using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord;

[XmlRoot("InsuranceSvcRq")]
public class InsuranceSvcRq
{
    [XmlElement("RqUID")]
    public Guid RqUId { get; set; }

    [XmlElement("CommlPkgPolicyAddRq")]
    public CommlPkgPolicyAddRq CommlPkgPolicyAddRq { get; set; }


}