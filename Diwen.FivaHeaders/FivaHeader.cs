namespace Diwen.FivaHeaders
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class FivaHeader
    {
        public DateTime InstanceCreationDateTime { get; set; }

        public string ReportingPeriod { get; set; }

        public string ReportingEntity { get; set; }

        public string TypeOfReportingInstitution { get; set; }

        public string ReportingApplicationName { get; set; }

        public string ReportingApplicationVersion { get; set; }

        public string ContactPersonFirstName { get; set; }

        public string ContactPersonLastName { get; set; }

        public string ContactPersonEmail { get; set; }

        public string ContactPersonTelephone { get; set; }

        public string Comment { get; set; }

        public string TestFlag { get; set; } = "false";

        public BasicHeader BasicHeader { get; set; } = new BasicHeader();

        [XmlIgnore]
        public bool Test
        {
            get => XmlConvert.ToBoolean(TestFlag.ToLower());
            set => TestFlag = XmlConvert.ToString(value);
        }

        [XmlIgnore]
        public string[] Files
        {
            get => BasicHeader.File.Select(f => f.FilePath).ToArray();
            set => BasicHeader.File = value.Select(f => new File { FilePath = f }).ToArray();
        }

        [XmlIgnore]
        public string ReportReferenceId
        {
            get => BasicHeader.ReportDataContext.ReportReferenceId;
            set => BasicHeader.ReportDataContext.ReportReferenceId = value;
        }

    }
}