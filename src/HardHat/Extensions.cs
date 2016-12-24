using HardHat;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class Extensions
    {
        public static IApplicationBuilder DnsPrefetch(this IApplicationBuilder app, bool allow = false)
        {
            app.UseMiddleware<DnsPrefetch>(allow);
            return app;
        }
        public static IApplicationBuilder AddFrameGuard(this IApplicationBuilder app, FrameGuardOptions options)
        {
            app.UseMiddleware<FrameGuard>(options);
            return app;
        }
        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, ulong maxAge, bool includeSubDomains = false, bool preload = false)
        {
            app.UseMiddleware<Hsts>(maxAge, includeSubDomains, preload);
            return app;
        }
    }
}
