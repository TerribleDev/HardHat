Prevent IE from opening websites in the context of your site

## Attack

In old versions of IE, IE would open html files in the context of your site. Lets say you uploaded a html file as your image for your profile picture in a social media site. Old versions of IE would actually render the html out!


## The Header

The `X-Download-Options` header can be set to noopen.

## Code 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseIENoOpen();
}

```