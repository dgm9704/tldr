namespace Diwen.FivaHeaders
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum ReportingEntityType
    {
        [XmlEnum("TK-tunnus")]
        TKtunnus,

        [XmlEnum("Y-tunnus")]
        Ytunnus,

        LEI,

        MFI,
    }

}