using System;
using System.Xml.Serialization;

namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("InsuranceSvcRq")]
    public class InsuranceSvcRq
    {
        //ToDo: Review if this is Acord
        [XmlElement("RqUID")]
        public Guid RqUid { get; set; }

        [XmlElement("CommlPkgPolicyAddRq")]
        public CommlPkgPolicyAddRq CommlPkgPolicyAddRq { get; set; }


    }
}