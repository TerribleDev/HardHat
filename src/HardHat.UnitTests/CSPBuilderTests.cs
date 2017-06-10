using HardHat.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HardHat.UnitTests
{
    public class CSPBuilderTests
    {
        [Fact]
        public void DefaultBuilderTests()
        {
            //"default-src 'self' http://*.example.com; "
            var builder = ContentSecurityHeaderBuilder.Build(new ContentSecurityPolicy() {
                DefaultSrc = new HashSet<string>() { CSPConstants.Self, CSPConstants.None, "http://*.example.com" },
                ScriptSrc = new HashSet<string>() { "http://*.example.com" },
                StyleSrc = new HashSet<string>() { "http://*.example.com" },
                ImgSrc = new HashSet<string>() { "http://*.example.com" },
                ConnectSrc = new HashSet<string>() { "http://*.example.com" },
                FontSrc = new HashSet<string>() { "http://*.example.com" },
                ObjectSrc = new HashSet<string>() { "http://*.example.com" },
                MediaSrc = new HashSet<string>() { "http://*.example.com" },
                ChildSrc = new HashSet<string>() { "http://*.example.com" },
                FormAction = new HashSet<string>() { "http://*.example.com" },
                FrameAncestors = new HashSet<string>() { "http://*.example.com" },
                PluginTypes = new HashSet<string>() { "http://*.example.com" },
                Sandbox = SandboxOption.AllowPointerLock

            });
            Assert.Equal<string>(@"default-src 'self' 'none' http://*.example.com; script-src http://*.example.com; style-src http://*.example.com; img-src http://*.example.com; connect-src http://*.example.com; font-src http://*.example.com; object-src http://*.example.com; media-src http://*.example.com; child-src http://*.example.com; form-action http://*.example.com; frame-ancestors http://*.example.com; sandbox allow-pointer-lock; plugin-types http://*.example.com;", builder);
        }

        [Fact]
        public void IsReportHeaderSetProperly()
        {
            var result = ContentSecurityHeaderBuilder.Build(new ContentSecurityPolicy()
            {
                ReportUri = "/yo",
                OnlySendReport = false
            });
            Assert.Equal("report-uri /yo;", result);

            var result2 = ContentSecurityHeaderBuilder.Build(new ContentSecurityPolicy()
            {
                ReportUri = "/yo",
                OnlySendReport = true
            });
            Assert.Equal("report-uri-Report-Only /yo;", result2);
        }
    }
}
