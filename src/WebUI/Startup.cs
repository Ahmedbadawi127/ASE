using Shipping.Application;
using Shipping.Application.Common.Interfaces;
using Shipping.Infrastructure;
using Shipping.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shipping.WebUI.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNet.OData.Extensions;
using Shipping.Shared.Dto;
using System;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Shipping.WebUI.Services;

namespace Shipping.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilter()));//.AddNewtonsoftJson();
            //services.AddOData();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddHttpClient<EmployeeServiceAPI>();
 

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Shipping API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            app.UseExceptionHandler("/Error");
           
            var HostHTTPOptionsSection = Configuration.GetSection("HostHTTPOptions");

            var UseForwardedHeaders = bool.Parse(HostHTTPOptionsSection?.GetSection("UseForwardedHeaders")?.Value ?? "false");
            var UseHsts = bool.Parse(HostHTTPOptionsSection?.GetSection("UseHsts")?.Value ?? "false");
            var UseHttpsRedirection = bool.Parse(HostHTTPOptionsSection?.GetSection("UseHttpsRedirection")?.Value ?? "false");
            var AddXForwardedForAndProto = bool.Parse(HostHTTPOptionsSection?.GetSection("AddXForwardedForAndProto")?.Value ?? "false");

            if (UseForwardedHeaders)
            {
                if (AddXForwardedForAndProto)
                {
                    app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });
                }
                else
                {
                    app.UseForwardedHeaders();
                }
            }

            if (UseHsts)
            {
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            if (UseHttpsRedirection)
            {
                app.UseHttpsRedirection();
            }
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();


            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default0",
                    pattern: "DynamicBP/DynamicStatusAction/{flow}/{roleName}/{StatusId:int}/{ActionName}/{subActionName}/{id:int}"); endpoints.MapControllerRoute(
     name: "default1",
     pattern: "DynamicBP/MyBFTasks/{flow}");

                endpoints.MapControllerRoute(
                    name: "default2",
                    pattern: "DynamicBP/GetStatusInstances/{flow}/{roleName}/{StatusId:int}");
                endpoints.MapControllerRoute(
                    name: "default3",
                    pattern: "DynamicBP/GetActions/{flow}/{roleName}/{StatusId:int}");

                endpoints.MapControllerRoute(
                                    name: "default2",
                                    pattern: "DynamicBP/GetStatusInstancesOD");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapFallbackToFile("index.html");//----------

            });


        }
    }
}
