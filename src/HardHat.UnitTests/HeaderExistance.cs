using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using Xunit;
using HardHat.Middlewares;

namespace HardHat.UnitTests
{
    public class HeaderExistance
    {
        Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
        Mock<HttpResponse> httpResponse = new Mock<HttpResponse>();
        Mock<IHeaderDictionary> httpDictionary = new Mock<IHeaderDictionary>();
        public HeaderExistance()
        {
            httpContextMock.SetupGet(a => a.Response).Returns(httpResponse.Object);
            httpResponse.SetupGet(a => a.Headers).Returns(httpDictionary.Object);
        }
        [Fact]
        public void NoIe()
        {
            httpDictionary.SetupSet(a => a[Constants.DowloadOptions] = Constants.NoOpen).Verifiable();
            new IENoOpen(null).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
        }
        [Fact]
        public void DnsPrefetch()
        {
            httpDictionary.SetupSet(a => a[Constants.DnsControlHeader] = "on").Verifiable();
            new DnsPrefetch(null, true).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
            httpDictionary.SetupSet(a => a[Constants.DnsControlHeader] = "off").Verifiable();
            new DnsPrefetch(null, false).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
        }
        [Fact]
        public void FrameGuard()
        {
            httpDictionary.SetupSet(a => a[Constants.FrameGuardHeader] = "awesome.com").Verifiable();
            new FrameGuard(null, new FrameGuardOptions("awesome.com")).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

            httpDictionary.SetupSet(a => a[Constants.FrameGuardHeader] = "SAMEORIGIN").Verifiable();
            new FrameGuard(null, new FrameGuardOptions(FrameGuardOptions.FrameGuard.SAMEORIGIN)).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

            httpDictionary.SetupSet(a => a[Constants.FrameGuardHeader] = "DENY").Verifiable();
            new FrameGuard(null, new FrameGuardOptions(FrameGuardOptions.FrameGuard.DENY)).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

        }

        [Fact]
        public void Hsts()
        {
            httpDictionary.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=5000").Verifiable();
            new Hsts(null, 5000).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

            httpDictionary.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=5000; includeSubDomains").Verifiable();
            new Hsts(null, 5000, true).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

            httpDictionary.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=5000; preload").Verifiable();
            new Hsts(null, 5000, false, true).Invoke(httpContextMock.Object);
            httpDictionary.Verify();

            httpDictionary.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=5000; includeSubDomains; preload").Verifiable();
            new Hsts(null, 5000, true, true).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
        }
        [Fact]
        public void NoSniff()
        {
            httpDictionary.SetupSet(a => a[Constants.XContentTypeOptions] = Constants.NoSniff).Verifiable();
            new NoSniff(null).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
        }

        [Fact]
        public void ReferrerPolicy()
        {
            httpDictionary.SetupSet(a => a[Constants.ReferrerPolicy] = "origin").Verifiable();
            new ReferrerPolicyMiddleware(null, HardHat.ReferrerPolicy.Origin).Invoke(httpContextMock.Object);
            httpDictionary.Verify();
        }
    }
}
