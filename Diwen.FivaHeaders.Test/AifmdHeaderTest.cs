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
    }
}
