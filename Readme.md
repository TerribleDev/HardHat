# Hard Hat

[![Build status](https://ci.appveyor.com/api/projects/status/orm7sjpwxde03pbj/branch/master?svg=true)](https://ci.appveyor.com/project/tparnell8/hardhat/branch/master)

<img src="Hat.png" width="350px"/>

HardHat is a set of .net core middleware that adds various headers to help protect your site from vulnerabilities. Inspired by [helmetJS](https://helmetjs.github.io). We have [some docs](docs/Readme.md) they are still a work in progress, so please feel free to submit changes to them.


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
            app.UseContentSecurityPolicy( // Provide a security policy so only content can come from trusted sources
                new ContentSecurityPolicyBuilder()
                .WithDefaultSource(CSPConstants.Self)
                .WithImageSource("http://images.mysite.com")
                .WithFontSource(CSPConstants.Self)
                .WithFrameAncestors(CSPConstants.None)
                .BuildPolicy()
               );
            app.UseHpkp(maxAge: 5184000, keys: new List<PublicKeyPin>{ // Prevent man in the middle attacks by providing a hash of your public keys
                new PublicKeyPin("cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=", HpKpCrypto.sha256),
                new PublicKeyPin("M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=", HpKpCrypto.sha256)
            }, includeSubDomains: true, reportUri: "/report", reportOnly: false);
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


* Install the nuget package `Install-Package HardHat`
* Add the middleware you desire to your configure block.