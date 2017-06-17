DNS Prefetch sets the `X-DNS-Prefetch-Control`

## Attack

When you visit a URL, the browser prefetches dns for a given link. This is a performance improvement, but can expose your users privacy by having them visit sites, they have never visited.


## The Header

The `X-DNS-Prefetch-Control` header tells browsers whether they should do DNS prefetching. 

## Code 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseDnsPrefetch(allow: false);
}

```