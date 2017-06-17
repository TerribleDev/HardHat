 the Referrer Policy middleware can control the behavior of the `Referer header` by setting the `Referrer-Policy` header.

## Attack

The referrer header is usually set by the browsers to tell websites where users are coming from. This causes privacy issues for your users by telling other sites where they are coming from.


## The Header

The `Referrer-Header` header can be set to `no-referrer` to prevent such behaviors. The header can also be set to `same-origin` to track users between your own site

## Code 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseReferrerPolicy(ReferrerPolicy.NoReferrer);
}

```