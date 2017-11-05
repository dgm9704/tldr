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
        private static Lazy<XmlSerializer> serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(FivaAIFMDHeader)));

        public new ReportingEntityType ReportingEntityType
        {
            get => base.ReportingEntityType;
            set => base.ReportingEntityType =
                (value != ReportingEntityType.MFI)
                ? value
                : throw new InvalidDataException($"ReportingEntityType {value:G} not allowed for AIFMD");
        }

        public void ToFile(string path)
        => ToFile(this, path, serializer.Value);

        public static FivaAIFMDHeader FromFile(string path)
        => FromFile<FivaAIFMDHeader>(path, serializer.Value);
    }
}
