namespace HardHat
{
    internal static class Constants
    {
        internal const string ContentSecurityPolicyHeader = "Content-Security-Policy";
        internal const string DnsControlHeader = "X-DNS-Prefetch-Control";
        internal const string FrameGuardHeader = "X-Frame-Options";
        internal const string DowloadOptions = "X-Download-Options";
        internal const string StrictTransportSecurity = "Strict-Transport-Security";
        internal const string MaxAge = "max-age";
        internal const string IncludeSubDomains = "; includeSubDomains";
        internal const string Preload = "; preload";
        internal const string NoOpen = "noopen";
        internal const string ReferrerPolicy = "Referrer-Policy";
        internal const string XContentTypeOptions = "X-Content-Type-Options";
        internal const string NoSniff = "nosniff";
        internal const string XXSProtection = "X-XSS-Protection";
        internal const string OneModeEqualsBlock = "1; mode=block";
        internal const string Zero = "0";
        internal const string UserAgent = "User-Agent";
        internal const string ServerHeader = "Server";
        internal const string semicolon = ";";
        internal const string HpKpHeader = "Public-Key-Pins";
        internal const string HpKpHeaderReportOnly = "Public-Key-Pins-Report-Only";
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

        internal static class CSPDirectives
        {
            internal const string DefaultSrc = "default-src";
            internal const string ScriptSrc = "script-src";
            internal const string StyleSrc = "style-src";
            internal const string ImgSrc = "img-src";
            internal const string ConnectSrc = "connect-src";
            internal const string FontSrc = "font-src";
            internal const string ObjectSrc = "object-src";
            internal const string MediaSrc = "media-src";
            internal const string Sandbox = "sandbox";
            internal const string ReportUri = "report-uri";
            internal const string ReportUriReportOnly = "report-uri-Report-Only";
            internal const string ChildSrc = "child-src";
            internal const string FormAction = "form-action";
            internal const string FrameAncestors = "frame-ancestors";
            internal const string PluginTypes = "plugin-types";
        }
    }
}
