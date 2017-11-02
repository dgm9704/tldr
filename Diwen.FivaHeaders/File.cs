namespace tldr
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader")]
    public partial class File
    {
        public string FilePath {get; set;}
    }
}