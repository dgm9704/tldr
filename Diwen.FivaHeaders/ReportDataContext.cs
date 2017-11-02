namespace Diwen.FivaHeaders
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    public partial class ReportDataContext
    {
        [XmlElement("ReportReferenceID")]
        public string ReportReferenceId {get; set;}
    }
}