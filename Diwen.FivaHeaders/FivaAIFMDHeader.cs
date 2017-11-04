namespace Diwen.FivaHeaders
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader")]
    [XmlRoot("FivaAIFMDHeader", Namespace = "http://www.fiva.fi/eu/fr/esrs/Header/FivaAIFMDHeader", IsNullable = false)]
    public partial class FivaAIFMDHeader : FivaHeader
    {

        public new ReportingEntityType ReportingEntityType
        {
            get => base.ReportingEntityType;
            set => base.ReportingEntityType =
                (value != ReportingEntityType.MFI)
                ? value
                : throw new InvalidDataException($"ReportingEntityType {value:G} not allowed for AIFMD");
        }

        private static Lazy<XmlSerializer> serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(FivaAIFMDHeader)));
        private static XmlSerializer Serializer => serializer.Value;

        public void ToFile(string path)
            => ToFile(this, path);

        public static FivaAIFMDHeader FromFile(string path)
        {
            using (var file = new FileStream(path, FileMode.Open))
                return (FivaAIFMDHeader)Serializer.Deserialize(file);
        }

        public static void ToFile(FivaHeader header, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                Serializer.Serialize(sw, header, Namespaces);
        }

        private static Lazy<XmlSerializerNamespaces> namespaces = new Lazy<XmlSerializerNamespaces>(() => GetNamespaces());
        internal static XmlSerializerNamespaces Namespaces => namespaces.Value;
        private static XmlSerializerNamespaces GetNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            xmlNames.ToList().ForEach(n => ns.Add(n.Key, n.Value));
            return ns;
        }

        private static Dictionary<string, string> xmlNames = new Dictionary<string, string>()
        {
            ["bh"] = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader",
            ["xsi"] = "http://www.w3.org/2001/XMLSchema-instance"
        };

    }
}
