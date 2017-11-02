namespace tldr
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    public partial class ReportDataContext
    {
        public string ReportReferenceID {get; set;}
    }
}