using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Helpers;
using GitHubFeatures.Services;
using GitHubFeatures.Services.Interfaces;

namespace GitHubFeatures
{
    public class GitHubOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddMvc();
            services.AddOptions();

            //Add user's services
            services.AddTransient<IUrlGenerator, UrlGenerator>();
            services.AddTransient<IGithubService, GitHubService>();
            services.AddTransient<ICSharpCompile, CSharpCompileService>();
            services.AddTransient<IResultChecker, ResultChecker>();
            services.Configure<GitHubOptions>(Configuration.GetSection("GitHubOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, 
            IUrlGenerator urlGenerator, IGithubService githubService, ICSharpCompile sharpCompile, IResultChecker resultChecker)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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
