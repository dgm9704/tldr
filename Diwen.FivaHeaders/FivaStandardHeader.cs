namespace Diwen.FivaHeaders
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    [XmlRoot("FivaStandardHeader", Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader", IsNullable = false)]
    public partial class FivaStandardHeader : FivaHeader
    {
        public static FivaStandardHeader FromFile(string path)
        => FromFile<FivaStandardHeader>(path);

        public void ToFile(string path)
        => ToFile<FivaStandardHeader>(this, path);
    }
}