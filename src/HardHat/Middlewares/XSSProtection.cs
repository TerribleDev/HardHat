using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HardHat.Middlewares
{
    public class XSSProtection
    {
        private readonly Regex ieMatch = new Regex(@"(?:\b(MS)?IE\s+|\bTrident\/7\.0;.*\s+rv:)(\d+)", RegexOptions.Compiled);
        private readonly bool addOldIE;
        private readonly RequestDelegate _next;
        public XSSProtection(RequestDelegate next, bool addOldIE = false)
        {
            _next = next;
            this.addOldIE = addOldIE;
        }

        public Task Invoke(HttpContext context)
        {
            var result = Constants.OneModeEqualsBlock;
            var userAgent = context.Request.Headers[Constants.UserAgent];
            if(!addOldIE && !string.IsNullOrWhiteSpace(userAgent))
            {
                var matches = ieMatch.Match(userAgent);
                int version;
                if(matches.Success && int.TryParse(matches?.Groups[2]?.Value, out version) && (version == 7 || version == 8 || version == 9))
                {
                    result = Constants.Zero;
                }
            }
            context.Response.Headers[Constants.XXSProtection] = result;
            return _next?.Invoke(context);
        }
    }
}
