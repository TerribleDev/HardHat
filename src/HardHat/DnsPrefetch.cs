using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat
{
    public class DnsPrefetch
    {
        private readonly string headerValue;
        private readonly RequestDelegate _next;
        public DnsPrefetch(RequestDelegate next, bool allow = false)
        {
            _next = next;
            headerValue = allow? "on": "off";
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.DnsControlHeader] = headerValue;
            return _next.Invoke(context);
        }
    }
}
