using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HardHat.Example
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseDnsPrefetch(allow: false);
            app.UseFrameGuard(new FrameGuardOptions("http://amazon.com"));
            app.UseHsts(maxAge: 5000, includeSubDomains: true, preload: false);
            app.UseReferrerPolicy(ReferrerPolicy.NoReferrer);
            app.UseIENoOpen();
            app.UseNoMimeSniff();
            app.UseCrossSiteScriptingFilters();
            app.UseContentSecurityPolicy(
                new ContentSecurityPolicyBuilder()
                .WithDefaultSource(CSPConstants.Self)
                .WithImageSource("http://images.mysite.com")
                .WithFontSource(CSPConstants.Self)
                .WithFrameAncestors(CSPConstants.None)
                .WithMediaSource(CSPConstants.Schemes.MediaStream)
                .BuildPolicy()
               );
            // use public key pinning
            app.UseHpkp(maxAge: 5184000, keys: new List<PublicKeyPin>{
                new PublicKeyPin("cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=", HpKpCrypto.sha256),
                new PublicKeyPin("M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=", HpKpCrypto.sha256)
            }, includeSubDomains: true, reportUri: "/report", reportOnly: false);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
