namespace Diwen.FivaHeaders
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader")]
    [XmlRoot("FivaAIFMDHeader", Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader", IsNullable = false)]
    public partial class FivaAIFMDHeader : FivaHeader
    {
        public EntityType ReportingEntityType { get; set; }

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader")]
        public enum EntityType
        {

            [XmlEnum("TK-tunnus")]
            TKtunnus,

            [XmlEnum("Y-tunnus")]
            Ytunnus,

            LEI,
        }

        public static FivaAIFMDHeader FromFile(string path)
        {
            var xml = new XmlSerializer(typeof(FivaAIFMDHeader));
            using (var file = new FileStream(path, FileMode.Open))
                return (FivaAIFMDHeader)xml.Deserialize(file);
        }
    }
}
