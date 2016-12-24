using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardHat
{
    public class Hsts
    {
        private readonly string value;
        private readonly RequestDelegate _next;
        public Hsts(RequestDelegate next, ulong maxAge, bool includeSubDomains = false, bool preload = false)
        {
            _next = next;
            var maxAgeInSeconds = maxAge.ToString();
            var subdomainLength = includeSubDomains ? Constants.IncludeSubDomains.Length : 0;
            var preloadLength = preload ? Constants.Preload.Length : 0;
            var requiredLength = maxAgeInSeconds.Length + Constants.MaxAge.Length + subdomainLength + preloadLength + 5; //2 semi-colons and some white space
            var stringBuilder = new StringBuilder($"{Constants.MaxAge}={maxAgeInSeconds}",requiredLength);
            if (includeSubDomains)
            {
                stringBuilder.Append(Constants.IncludeSubDomains);
            }
            if (preload)
            {
                stringBuilder.Append(Constants.Preload);
            }
            value = stringBuilder.ToString();
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.StrictTransportSecurity] = value;
            return _next.Invoke(context);
        }
    }
}
