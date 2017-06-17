the HTTP Public Key Pinning module helps you set the `Public-Key-Pins` header to prevent person-in-the-middle attacks.

## Attack

If hackers can intercept secure requests to your website, they can gain credit card information, or passwords of your customers.


## The Header

The `Public-Key-Pins` header gives the browsers a hash of your public keys. This verifies to the browser if they are actually talking to your website

## Code 

You can set the max age of the cache in seconds. You provide base64 encoded keys, and 

```csharp

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
            app.UseHpkp(maxAge: 5184000, 
            keys: new List<PublicKeyPin>{
                new PublicKeyPin("cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=", HpKpCrypto.sha256),
                new PublicKeyPin("M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=", HpKpCrypto.sha256)
            }, 
            includeSubDomains: true, 
            reportUri: "/report", 
            reportOnly: false);
}

```