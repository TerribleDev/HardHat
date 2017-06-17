The Cross Site Scripting filter sets the `X-XSS-Protection` to prevent reflected XSS attacks

## Attack

If someone can run JavaScript on your page, they can attack your users and do a lot of bad things. Sometimes people can inject script tags through query strings, and thus attack your users

## The Header

This middleware simply allows the browsers to detect and combat reflective XSS attacks. This will not save you against all attacks, but its a good start. Note in older versions of IE, this causes more security issues so we turn it off.

## Code 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseCrossSiteScriptingFilters();
    //app.UseCrossSiteScriptingFilters(addOldIE: true); if you want older versions of IE to get the header
}

```