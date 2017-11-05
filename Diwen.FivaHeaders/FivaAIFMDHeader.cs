namespace Diwen.FivaHeaders
{
    using System;
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
                : throw new ArgumentException( $"ReportingEntityType {value:G} not allowed for AIFMD", nameof(value));
        }

        public static FivaAIFMDHeader FromFile(string path)
        => FromFile<FivaAIFMDHeader>(path);

        public void ToFile(string path)
        => ToFile<FivaAIFMDHeader>(this, path);
    }
}
