Set the `Strict-Transport-Security` header which tells the browser to use https

## Attack

Most websites only want to server over https, but often a http request is made and a user is redirected to https. This middleware caches the knowledge to use https, so future http requests cannot be man in the middle attacked


## The Header

the `Strict-Transport-Security` header controls the browsers behavior to default to https

## Code 


Apart from setting a max age, you can include your subdomains. Ontop of all, you can include a preload header, which is required if you submit your [site to google](https://hstspreload.org/). Submitting your site to google will mean that the hsts header will be cached in the browsers ahead of time. 

```csharp


public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseHsts(maxAge: 5000, includeSubDomains: true, preload: false);
}

```