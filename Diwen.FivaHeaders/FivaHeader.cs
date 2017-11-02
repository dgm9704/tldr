namespace Diwen.FivaHeaders
{
    using System;

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
    }
}