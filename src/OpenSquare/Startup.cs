using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenSquare.Setting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace OpenSquare
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //  builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<Core.EF.SessionManager.Session>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var i = new Auth0Settings() { ClientId = Configuration.GetSection("Auth0:ClientId").Value, Domain = Configuration.GetSection("Auth0:Domain").Value };
            //services.Configure<Auth0Settings>(new System.Action<Auth0Settings>());
            //var o = Configuration.GetSection("Auth0");
            //services.Configure<Auth0Settings>();
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            //   services.AddSingleton<Core.Business.Interface.IUserBS, Core.Business.Domain.UserBS>();
            services.AddMvc();


            // Add application services.
            services.AddSingleton<Core.Business.Interface.IUserBS, Core.Business.Domain.UserBS>();
            services.AddSingleton<Core.Business.Interface.IProfile, Core.Business.Domain.ProfileBS>();

            //services.AddTransient<ISmsSender, AuthMessageSender>();
        }


        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole();

            var logger = loggerfactory.CreateLogger("Auth0");
            //var settings = app.ApplicationServices.GetService<IOptions<Auth0Settings>>();
            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
            //{
            //    Audience = settings.Value.ClientId,
            //    Authority = settings.Value.Domain,
            //    Events = new JwtBearerEvents()
            //    {
            //        OnAuthenticationFailed = context =>
            //        {
            //            logger.LogError("Authentication failed.", context.Exception);
            //            return Task.FromResult(0);
            //        }
            //        //},
            //        //OnTokenValidated = context => {
            //        //    var claimsIdentity =   context.AutehticationTicket  AuthenticationTicket.Principal.Identity as ClaimsIdentity;
            //        //            claimsIdentity.AddClaim(new Claim("Token",
            //        //                context.Request.Headers["Authorization"][0].Substring(context.AuthenticationTicket.AuthenticationScheme.Length + 1)));
            //        //    return Task.FromResult(0);
            //        //}
            //    }




            //});
            // app.UseJwtBearerAuthentication(options =>
            // {
            //options.Audience = settings.Value.ClientId;
            //options.Authority = $"https://{settings.Value.Domain}";
            //options.Events = new JwtBearerEvents
            //{
            //    OnAuthenticationFailed = context =>
            //    {
            //        logger.LogError("Authentication failed.", context.Exception);
            //        return Task.FromResult(0);
            //    },
            //    OnValidatedToken = context =>
            //    {
            //        var claimsIdentity = context.AuthenticationTicket.Principal.Identity as ClaimsIdentity;
            //        claimsIdentity.AddClaim(new Claim("id_token",
            //            context.Request.Headers["Authorization"][0].Substring(context.AuthenticationTicket.AuthenticationScheme.Length + 1)));

            //        // OPTIONAL: you can read/modify the claims that are populated based on the JWT
            //        // claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, claimsIdentity.FindFirst("name").Value));
            //        return Task.FromResult(0);
            //    }
            //};
            // });
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //    loggerFactory.AddDebug();

        //    app.UseApplicationInsightsRequestTelemetry();


        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseDatabaseErrorPage();
        //       // app.UseBrowserLink();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseApplicationInsightsExceptionTelemetry();

        //    app.UseStaticFiles();

        //   // app.UseIdentity();

        //    // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}


//    public class Startup
//    {
//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            loggerFactory.AddConsole();

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync("Hello World!");
//            });
//        }
//    }
//}
