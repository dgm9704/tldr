namespace tldr
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    [XmlRoot("BasicHeader", Namespace = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader", IsNullable = false)]
    public partial class BasicHeader
    {
        public ReportDataContext ReportDataContext { get; set; }

        [XmlElement("File")]
        public File[] File { get; set; }
    }
}