using HardHat;

namespace Microsoft.AspNetCore.Builder
{
    public static class Extensions
    {
        public static IApplicationBuilder DnsPrefetch(this IApplicationBuilder app, bool allow = false) => app.UseMiddleware<DnsPrefetch>(allow);
        public static IApplicationBuilder AddFrameGuard(this IApplicationBuilder app, FrameGuardOptions options) => app.UseMiddleware<FrameGuard>(options);
        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, ulong maxAge, bool includeSubDomains = false, bool preload = false) => app.UseMiddleware<Hsts>(maxAge, includeSubDomains, preload);
        public static IApplicationBuilder AddIENoOpen(this IApplicationBuilder app) => app.UseMiddleware<IENoOpen>();
        public static IApplicationBuilder AddReferrerPolicy(this IApplicationBuilder app, ReferrerPolicy policy) => app.UseMiddleware<ReferrerPolicyMiddlewear>(policy);
    }
}
