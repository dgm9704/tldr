namespace tldr
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
    [XmlRoot("FivaStandardHeader", Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader", IsNullable = false)]
    public partial class FivaStandardHeader
    {
        public EntityType ReportingEntityType { get; set; }

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.finanssivalvonta.fi/Raportointi/xbrl/Documents/FivaStandardHeader")]
        public enum EntityType
        {
            [XmlEnum("TK-tunnus")]
            TKtunnus,

            [XmlEnum("Y-tunnus")]
            Ytunnus,

            LEI,

            MFI,
        }

    }
}