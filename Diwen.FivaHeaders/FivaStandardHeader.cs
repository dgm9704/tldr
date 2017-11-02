namespace Diwen.FivaHeaders
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    [XmlRoot("FivaStandardHeader", Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader", IsNullable = false)]
    public partial class FivaStandardHeader : FivaHeader
    {
        private static Lazy<XmlSerializer> serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(FivaAIFMDHeader)));
        private static XmlSerializer Serializer => serializer.Value;

    }
}