//  Copyright (c) 2017-2019 John Nordberg 
//  Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.

namespace Diwen.FivaHeaders.Test
{
    using System;
    using System.IO;
    using Xunit;

    public class StandardHeaderTest
    {
        [Fact]
        public void Import()
        {
            var path = Path.Combine("data", "standard_header.xml");
            var header = FivaStandardHeader.FromFile(path);
        }

        [Fact]
        public void Export()
        {
            var path = Path.Combine("data", "standard_header_out.xml");
            var header = CreateFivaStandardHeader();
            header.ToFile(path);
        }

        [Fact]
        public void Roundtrip()
        {
            var tempFile = Path.Combine("data", "standard_header_temp.xml");

            var first = CreateFivaStandardHeader();
            first.ToFile(tempFile);
            var second = FivaStandardHeader.FromFile(tempFile);

            Assert.True(first.ContentMatch(second));
        }

        [Fact]
        public void CreateXmlDocument()
        {
            var tempFile = Path.Combine("data", "standard_header.xml");

            var first = CreateFivaStandardHeader();
            var document = first.ToXmlDocument();

            Assert.True(document.DocumentElement.ChildNodes.Count > 1);
        }


        private FivaStandardHeader CreateFivaStandardHeader()
        => new FivaStandardHeader
        {
            InstanceCreationDateTime = new DateTime(2018, 03, 18, 13, 05, 42, DateTimeKind.Local),
            ReportingPeriod = new DateTime(2018, 03, 31),
            ReportingEntityType = ReportingEntityType.LEI,
            ReportingEntity = "00000000000000000098",
            TypeOfReportingInstitution = "888",
            ReportingApplicationName = "ReportingApplication",
            ReportingApplicationVersion = "1.0.0",
            ContactPersonFirstName = "First",
            ContactPersonLastName = "Last",
            ContactPersonEmail = "first.last@example.com",
            ContactPersonTelephone = "+358 00 000 0000",
            TestFlag = true,
	    	NumberOfFiles = 1,
	   		ModuleCode = "spv",
            ReportReferenceId = "90aeaa55-275c-4410-874f-951142307d59",
            Files = new[] { "spv_888_00000000000000000098_20180331.xbrl" },
        };
    }
}
