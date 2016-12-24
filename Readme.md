HardHat adds various headers to help protect your site from vulnerablities.


In short this allows:


```csharp

            app.DnsPrefetch(allow: false); //turn off dns prefetch to keep privacy of users on site
            app.AddFrameGuard(new FrameGuardOptions(FrameGuardOptions.FrameGuard.SAMEORIGIN)); //prevent content from being loaded in an iframe unless its within the same origin
            app.UseHsts(maxAge: 5000, includeSubDomains: true, preload: false); //enforce hsts


```

todo:

CSP
ie NoOpen
don't sniff mime type
XSS protection
disable referer

