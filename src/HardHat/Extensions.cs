using HardHat;

namespace Microsoft.AspNetCore.Builder
{
    public static class Extensions
    {
        /// <summary>
        /// Browsers can start DNS requests from URLs in your page. This improves performance, but can cause a privacy issue to your users.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDnsPrefetch(this IApplicationBuilder app, bool allow = false) => app.UseMiddleware<DnsPrefetch>(allow);
        /// <summary>
        /// The X-Frame-Options HTTP response header can be used to indicate whether or not a browser should be allowed to render a page in a frame, iframe, or object . Sites can use this to avoid clickjacking attacks, by ensuring that their content is not embedded into other sites.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseFrameGuard(this IApplicationBuilder app, FrameGuardOptions options) => app.UseMiddleware<FrameGuard>(options);
        /// <summary>
        /// The Strict-Transport-Security HTTP header tells browsers to stick with HTTPS and never visit the insecure HTTP version. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="maxAge">how long the browser should use https in seconds</param>
        /// <param name="includeSubDomains">include subdomains?</param>
        /// <param name="preload">is preloaded with google? https://hstspreload.org/ if you don't know then set this to false</param>
        /// <returns></returns>
        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, ulong maxAge, bool includeSubDomains = false, bool preload = false) => app.UseMiddleware<Hsts>(maxAge, includeSubDomains, preload);
        /// <summary>
        /// This middleware sets the X-Download-Options to prevent Internet Explorer from executing downloads in your site’s context.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIENoOpen(this IApplicationBuilder app) => app.UseMiddleware<IENoOpen>();
        /// <summary>
        ///A user could upload an image with the .jpg file extension but its contents are actually HTML. Visiting that image could cause the browser to “run” the HTML page, which could contain malicious JavaScript! This is because the MIME type is "sniffed" by the browser
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNoMimeSniff(this IApplicationBuilder app) => app.UseMiddleware<NoSniff>();
        /// <summary>
        /// Typically when users are directed away from your site they have a referrer header. This says where the request is coming from, which has privacy implications for your users.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="policy">A referrer policy. You can read more about them here: https://www.w3.org/TR/referrer-policy/#referrer-policies </param>
        /// <returns></returns>
        public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app, ReferrerPolicy policy) => app.UseMiddleware<ReferrerPolicyMiddlewear>(policy);
        /// <summary>
        /// This adds the X-XSS-Protection header which allows the browser to detect and block some xss attacks
        /// </summary>
        /// <param name="app"></param>
        /// <param name="addOldIE">turning this on for ie8 and 9 can actually cause worse vulnerabilities. By default we do not add old IE, but you can override this behavior</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCrossSiteScriptingFilters(this IApplicationBuilder app, bool addOldIE = false) => app.UseMiddleware<XSSProtection>(addOldIE);
    }
}
