namespace Diwen.FivaHeaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    [XmlRoot("FivaStandardHeader", Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader", IsNullable = false)]
    public partial class FivaStandardHeader : FivaHeader
    {
        private static Lazy<XmlSerializer> serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(FivaStandardHeader)));

        public void ToFile(string path)
            => ToFile(this, path, serializer.Value);

        public static FivaStandardHeader FromFile(string path)
            => FromFile<FivaStandardHeader>(path, serializer.Value);
    }
}