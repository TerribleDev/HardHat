<img src="Hat.png" width="350px"/>

HardHat adds various headers to help protect your site from vulnerablities.


In short this allows:


```csharp

 // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ...
            app.DnsPrefetch(allow: false); //turn off dns prefetch to keep privacy of users on site
            app.AddFrameGuard(new FrameGuardOptions(FrameGuardOptions.FrameGuard.SAMEORIGIN)); //prevent content from being loaded in an iframe unless its within the same origin
            app.UseHsts(maxAge: 5000, includeSubDomains: true, preload: false); //enforce hsts
            app.AddReferrerPolicy(ReferrerPolicy.NoReferrer);
            app.AddIENoOpen();
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

todo:

* CSP
* don't sniff mime type
* XSS protection

