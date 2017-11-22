//  Copyright (c) 2017 John Nordberg 
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

        private FivaStandardHeader CreateFivaStandardHeader()
        => new FivaStandardHeader
        {
            InstanceCreationDateTime = new DateTime(2016, 04, 15, 12, 53, 05, DateTimeKind.Local),
            ReportingPeriod = "2014-12-31",
            ReportingEntityType = ReportingEntityType.LEI,
            ReportingEntity = "00000000000000000098",
            TypeOfReportingInstitution = "410",
            ReportingApplicationName = "ApplicationX",
            ReportingApplicationVersion = "1.0.0",
            ContactPersonFirstName = "Tyyni",
            ContactPersonLastName = "Testaaja",
            ContactPersonEmail = "tyyni.testaaja@fiva.fi",
            ContactPersonTelephone = "+358-00 000 0000",
            Comment = "Just for comment purposes",
            Test = false,
            ReportReferenceId = "S2_ars_example_test_1",
            Files = new[] { "qes_410_00000000000000000098_20160331.xbrl" },
        };
    }
}
