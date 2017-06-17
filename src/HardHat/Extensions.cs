using HardHat;
using HardHat.Middlewares;
using System;
using System.Collections.Generic;

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
        /// The Strict-Transport-Security HTTP header tells browsers to stick with HTTPS and never visit the insecure HTTP version. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="maxAge"></param>
        /// <param name="includeSubDomains"></param>
        /// <param name="preload"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, TimeSpan maxAge, bool includeSubDomains = false, bool preload = false)
        {
            app.UseMiddleware<Hsts>(Convert.ToUInt64(maxAge.TotalSeconds), includeSubDomains, preload);
            return app;
        }
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
        public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app, ReferrerPolicy policy) => app.UseMiddleware<ReferrerPolicyMiddleware>(policy);
        /// <summary>
        /// This adds the X-XSS-Protection header which allows the browser to detect and block some xss attacks
        /// </summary>
        /// <param name="app"></param>
        /// <param name="addOldIE">turning this on for ie8 and 9 can actually cause worse vulnerabilities. By default we do not add old IE, but you can override this behavior</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCrossSiteScriptingFilters(this IApplicationBuilder app, bool addOldIE = false) => app.UseMiddleware<XSSProtection>(addOldIE);

        /// <summary>
        /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks
        /// </summary>
        /// <param name="app"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder app, ContentSecurityPolicy policy) => app.UseMiddleware<ContentSecurityPolicyMiddleware>(policy);

        /// <summary>
        /// To ensure the authenticity of a server's public key used in TLS sessions, this public key is wrapped into a X.509 certificate which is usually signed by a certificate authority (CA). Web clients such as browsers trust a lot of these CAs, which can all create certificates for arbitrary domain names. If an attacker is able to compromise a single CA, they can perform MITM attacks on various TLS connections. HPKP can circumvent this threat for the HTTPS protocol by telling the client which public key belongs to a certain web server.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="maxAge">The time, in seconds, that the browser should remember that this site is only to be accessed using one of the defined keys.</param>
        /// <param name="keys"></param>
        /// <param name="includeSubDomains">If this optional parameter is specified, this rule applies to all of the site's subdomains as well.</param>
        /// <param name="reportUri">If this optional parameter is specified, pin validation failures are reported to the given URL.</param>
        /// <param name="reportOnly">Instead of using a Public-Key-Pins header you can also use a Public-Key-Pins-Report-Only header. This header only sends reports to the report-uri specified in the header and does still allow browsers to connect to the webserver even if the pinning is violated.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseHpkp(this IApplicationBuilder app, ulong maxAge, ICollection<PublicKeyPin> keys, bool includeSubDomains = false, string reportUri = "", bool reportOnly = false) => app.UseMiddleware<Hpkp>(maxAge, keys, includeSubDomains, reportUri, reportOnly);

        /// <summary>
        /// change or remove the server header.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="header">Set this to null or empty string to remove the header entirely</param>
        /// <returns></returns>
        public static IApplicationBuilder UseServerHeader(this IApplicationBuilder app, string header = "")
        {
            if (string.IsNullOrWhiteSpace(header))
            {
                return app.UseMiddleware<ServerHeader>(string.Empty);
            }
            return app.UseMiddleware<ServerHeader>(header);
        }
    }
}
