namespace Diwen.FivaHeaders
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
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

        [XmlIgnore]
        public string[] Files
        {
            get => BasicHeader.File.Select(f => f.FilePath).ToArray();
            set => BasicHeader.File = value.Select(f => new File { FilePath = f }).ToArray();
        }

        [XmlIgnore]
        public string ReportReferenceID
        {
            get => BasicHeader.ReportDataContext.ReportReferenceID;
            set => BasicHeader.ReportDataContext.ReportReferenceID = value;
        }

        private static XmlSerializer serializer;
        private static XmlSerializerNamespaces ns;

        private static XmlSerializer GetSerializer()
        {
            if (serializer == null)
                serializer = new XmlSerializer(typeof(FivaAIFMDHeader));
            return serializer;
        }

        private static XmlSerializerNamespaces GetNamespaces()
        {
            if (ns == null)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("bh", "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            }
            return ns;
        }

        public void ToFile(string path)
            => ToFile(this, path);

        public static FivaAIFMDHeader FromFile(string path)
        {
            var xml = GetSerializer();
            var ns = GetNamespaces();
            using (var file = new FileStream(path, FileMode.Open))
                return (FivaAIFMDHeader)xml.Deserialize(file);
        }

        public static void ToFile(FivaHeader header, string path)
        {
            var xml = GetSerializer();
            var ns = GetNamespaces();

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                xml.Serialize(sw, header, ns);
        }
    }
}
