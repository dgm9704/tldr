namespace Diwen.FivaHeaders
{
    using System;
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

        public bool ContentMatch(FivaAIFMDHeader other)
        => other != null
            && other.Test == this.Test
            && other.ReportingEntityType == this.ReportingEntityType
            && other.ReportReferenceId.Equals(this.ReportReferenceId)
            && other.TypeOfReportingInstitution.Equals(this.TypeOfReportingInstitution)
            && other.ReportingEntity.Equals(this.ReportingEntity)
            && other.ReportingPeriod.Equals(this.ReportingPeriod)
            && other.Comment.Equals(this.Comment)
            && other.Files.SequenceEqual(this.Files);

            // InstanceCreationDateTime = new DateTime(2015, 01, 07, 16, 22, 00, DateTimeKind.Local),

            // ReportingApplicationName = "ApplicationX",
            // ReportingApplicationVersion = "1.0.0",

            // ContactPersonFirstName = "Tylle",
            // ContactPersonLastName = "Testaaja",
            // ContactPersonEmail = "tylle.testaaja@fiva.fi",
            // ContactPersonTelephone = "+358-00 000 0000",

    }
}
