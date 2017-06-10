# Hard Hat

<img src="Hat.png" width="350px"/>

HardHat is a set of .net core middleware that adds various headers to help protect your site from vulnerabilities. Inspired by [helmetJS](https://helmetjs.github.io). Currently in beta, Content Security Policy, Unit tests, documentation due before 1.0.0. Even still, this should work fine.


In short this allows:


```csharp

 // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ...
            app.UseDnsPrefetch(allow: false); //turn off dns prefetch to protect the privacy of users
            app.UseFrameGuard(new FrameGuardOptions(FrameGuardOptions.FrameGuard.SAMEORIGIN)); //prevent clickjacking, by not allowing your site to be rendered in an iframe
            //  app.UseFrameGuard(new FrameGuardOptions("otherdomain.com")); or allow iframes on another domain
            app.UseHsts(maxAge: 5000, includeSubDomains: true, preload: false); //tell browsers to always use https for the next 5000 seconds
            app.UseReferrerPolicy(ReferrerPolicy.NoReferrer); // do not include the referrer header when linking away from your site to protect your users privacy
            app.UseIENoOpen(); // don't allow old ie to open files in the context of your site
            app.UseNoMimeSniff(); // prevent MIME sniffing https://en.wikipedia.org/wiki/Content_sniffing
            app.UseCrossSiteScriptingFilters(); //add headers to have the browsers auto detect and block some xss attacks
            app.UseContentSecurityPolicy(
                new ContentSecurityPolicyBuilder()
                .WithDefaultSource(CSPConstants.Self)
                .WithImageSource("http://images.mysite.com")
                .WithFontSource(CSPConstants.Self)
                .WithFrameAncestors(CSPConstants.None)
                .BuildPolicy()
               );
            ...
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }



```

## Getting started


* Install the nuget package `Install-Package HardHat -Pre`
* Add the middleware you desire to your configure block.