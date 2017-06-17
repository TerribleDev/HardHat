using HardHat.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HardHat.UnitTests
{
    public class ExpectCtHeaderTests
    {
        [Fact]
        public void TestExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => ExpectCtHeaderBuilder.Build(0, string.Empty));
        }

        [Fact]
        public void TestHeader()
        {
            var result = ExpectCtHeaderBuilder.Build(0, "/awesome");

            Assert.Equal("max-age=0; report-uri=\"/awesome\"", result);
        }

        [Fact]
        public void TestHeaderWithEnforce()
        {
            var result = ExpectCtHeaderBuilder.Build(0, "/awesome", true);

            Assert.Equal("max-age=0; report-uri=\"/awesome\"; enforce", result);
        }
    }
}
