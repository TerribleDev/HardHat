using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat
{
    public static class Constants
    {
        public static string DnsControlHeader = "X-DNS-Prefetch-Control";
        public static string FrameGuardHeader = "X-Frame-Options";
        public static string StrictTransportSecurity = "Strict-Transport-Security";
        public static string MaxAge = "max-age";
        public static string IncludeSubDomains = "; includeSubDomains";
        public static string Preload = "; preload";
    }
}
