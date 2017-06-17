the Don’t Sniff Mimetype middleware, noSniff, helps prevent browsers from trying to guess ("sniff") the MIME type.

## Attack

Some browsers will detect what the mime type of a file is, even if the webserver says something else. Lets say someone uploads a script file to your website as their profile. Even though the webserver could say the mime type is one thing, the browser could interpret it as javascript and execute it!


## The Header

The `X-Content-Type-Options` header can be set to `nosniff` to prevent mime sniffing.

## Code 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseNoMimeSniff();
}

```