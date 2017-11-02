namespace Diwen.FivaHeaders.Test
{
    using System;
    using System.IO;
    using Xunit;
    public class AifmdHeaderTest
    {
        [Fact]
        public void Import()
        {
            var path = Path.Combine("data", "aifmd_header.xml");
            var aifmdHeader = FivaAIFMDHeader.FromFile(path);
        }

        [Fact]
        public void Export()
        {
            var path = Path.Combine("data", "aifmd_header_out.xml");
            var aifmdHeader = CreateFivaAIFMDHeader();
            aifmdHeader.ToFile(path);
        }

        private FivaAIFMDHeader CreateFivaAIFMDHeader()
        => new FivaAIFMDHeader
        {
            InstanceCreationDateTime = new DateTime(2015, 01, 07, 16, 22, 00),
            ReportingPeriod = "2014-12-31",
            ReportingEntityType = FivaAIFMDHeader.EntityType.TKtunnus,
            ReportingEntity = "9999999",
            TypeOfReportingInstitution = "354",
            ReportingApplicationName = "ApplicationX",
            ReportingApplicationVersion = "1.0.0",
            ContactPersonFirstName = "Tylle",
            ContactPersonLastName = "Testaaja",
            ContactPersonEmail = "tylle.testaaja@fiva.fi",
            ContactPersonTelephone = "+358-00 000 0000",
            Comment = "Revision123",
            TestFlag = "false",
            ReportReferenceID = "AIFMD_AIFM_00001",
            Files = new[] { "AIF_354_9999999_20141231.encrypted.xml" },
        };
    }
}
