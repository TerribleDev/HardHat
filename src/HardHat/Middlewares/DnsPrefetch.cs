using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HardHat.Middlewares
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
            return _next?.Invoke(context);
        }
    }
}
