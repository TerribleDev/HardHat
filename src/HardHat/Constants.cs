using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat
{
    internal static class Constants
    {
        internal const string DnsControlHeader = "X-DNS-Prefetch-Control";
        internal const string FrameGuardHeader = "X-Frame-Options";
        internal const string StrictTransportSecurity = "Strict-Transport-Security";
        internal const string MaxAge = "max-age";
        internal const string IncludeSubDomains = "; includeSubDomains";
        internal const string Preload = "; preload";
        internal const string DowloadOptions = "X-Download-Options";
        internal const string NoOpen = "noopen";
        internal const string ReferrerPolicy = "Referrer-Policy";

        internal static class Referrers 
        {
            internal const string NoReferrer = "no-referrer";
            internal const string NoReferrerWhenDowngrade = "no-referrer-when-downgrade";
            internal const string SameOrigin = "same-origin";
            internal const string Origin = "origin";
            internal const string StrictOrigin = "strict-origin";
            internal const string OriginWhenCrossOrigin = "origin-when-cross-origin";
            internal const string StrictOriginWhenCrossOrigin = "strict-origin-when-cross-origin";
            internal const string UnsafeUrl = "unsafe-url";
        }
    }
}
