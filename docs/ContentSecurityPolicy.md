sets the `Content-Security-Policy` header which can help protect against malicious injection of JavaScript, CSS, plugins, and more.


## Attack

When hackers can place content onto your site, they can do bad things! For example, javascript executing can give them someones credit card data. Or they could place a 1x1 transparent gif on your site to collect data.


## The Header

The `Content-Security-Policy` header tells browsers which domains content can come from. This is essentially a white list of domains where content can be loaded. For example, images could only come from your images subdomain.

## Code 

Here we are saying images can come from any subdomain of my site. Fonts can come from the current domain.

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
                app.UseContentSecurityPolicy(
                new ContentSecurityPolicyBuilder()
                .WithDefaultSource(CSPConstants.Self)
                .WithImageSource("http://*.mysite.com")
                .WithFontSource(CSPConstants.Self)
                .WithFrameAncestors(CSPConstants.None)
                .BuildPolicy()
               );
}

```