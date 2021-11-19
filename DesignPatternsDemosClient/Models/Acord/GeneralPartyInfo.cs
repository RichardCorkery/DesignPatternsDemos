﻿using System.Xml.Serialization;

//$$$RAC: Fix all of the namespaces
namespace DesignPatternsDemosClient.Models.Acord
{
    [XmlRoot("GeneralPartyInfo")]
    public class GeneralPartyInfo 
    {
        [XmlElement("NameInfo")]
        public NameInfo NameInfo { get; set; }
        [XmlElement("Addr")]

        //$$$RAC: Make everything nullable
        public Addr Addr { get; set; }

    }
}
