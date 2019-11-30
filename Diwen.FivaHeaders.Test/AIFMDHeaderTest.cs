//  Copyright (c) 2017-2019 John Nordberg 
//  Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.

namespace Diwen.FivaHeaders.Test
{
    using System;
    using System.IO;
    using Xunit;
    public class AIFMDHeaderTest
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

        [Fact]
        public void Roundtrip()
        {
            var tempFile = Path.Combine("data", "aifmd_header_temp.xml");

            var first = CreateFivaAIFMDHeader();
            first.ToFile(tempFile);
            var second = FivaAIFMDHeader.FromFile(tempFile);

            Assert.True(first.ContentMatch(second));
        }

        [Fact]
        public void CreateXmlDocument()
        {
            var tempFile = Path.Combine("data", "standard_header.xml");

            var first = CreateFivaAIFMDHeader();
            var document = first.ToXmlDocument();

            Assert.True(document.DocumentElement.ChildNodes.Count > 1);
        }

        private static FivaAIFMDHeader CreateFivaAIFMDHeader()
        => new FivaAIFMDHeader
        {
            InstanceCreationDateTime = new DateTime(2018, 03, 18, 13, 03, 27, DateTimeKind.Local), 
            ReportingPeriod = "2017-12-31",
            ReportingEntityType = ReportingEntityType.TKtunnus,
            ReportingEntity = "9999999",
            TypeOfReportingInstitution = "777",
            ReportingApplicationName = "ReportingApplication",
            ReportingApplicationVersion = "1.0.0",
            ContactPersonFirstName = "First",
            ContactPersonLastName = "Last",
            ContactPersonEmail = "first.last@example.com",
            ContactPersonTelephone = "+358 00 000 0000",
            Comment = "Foo",
	    NumberOfFiles = 1,
            Test = true,
            ReportReferenceId = "ab17e980-876a-45a4-87d8-952ba797eae8",
            Files = new[] { "AIF_777_9999999_20171231.encrypted.xml" },
        };
    }
}
