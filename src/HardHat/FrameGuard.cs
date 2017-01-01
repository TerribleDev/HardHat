using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace HardHat
{
    public class FrameGuard
    {
        private readonly FrameGuardOptions options;
        private readonly RequestDelegate next;
        public FrameGuard(RequestDelegate next, FrameGuardOptions options)
        {
            this.next = next;
            this.options = options;
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        public Task Invoke(HttpContext context)
        {
            if (options.guard.HasValue)
            {
                context.Response.Headers[Constants.FrameGuardHeader] = Enum.GetName(typeof(FrameGuardOptions.FrameGuard), options.guard);
            }
            else if (!string.IsNullOrWhiteSpace(options.domain))
            {
                context.Response.Headers[Constants.FrameGuardHeader] = options.domain;
            }
            else
            {
                throw new ArgumentException("Frameguard, or domain not set");
            }
            return next.Invoke(context);
        }
    }
}
