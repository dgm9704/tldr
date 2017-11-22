//  Copyright (c) 2017 John Nordberg 
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

        private static FivaAIFMDHeader CreateFivaAIFMDHeader()
        => new FivaAIFMDHeader
        {
            InstanceCreationDateTime = new DateTime(2015, 01, 07, 16, 22, 00, DateTimeKind.Local),
            ReportingPeriod = "2014-12-31",
            ReportingEntityType = ReportingEntityType.TKtunnus,
            ReportingEntity = "9999999",
            TypeOfReportingInstitution = "354",
            ReportingApplicationName = "ApplicationX",
            ReportingApplicationVersion = "1.0.0",
            ContactPersonFirstName = "Tylle",
            ContactPersonLastName = "Testaaja",
            ContactPersonEmail = "tylle.testaaja@fiva.fi",
            ContactPersonTelephone = "+358-00 000 0000",
            Comment = "Revision123",
            Test = false,
            ReportReferenceId = "AIFMD_AIFM_00001",
            Files = new[] { "AIF_354_9999999_20141231.encrypted.xml" },
        };
    }
}
