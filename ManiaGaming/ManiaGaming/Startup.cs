using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.MSSQLContext;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManiaGaming
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            // Sql contexts
            services.AddScoped<IProductContext, MSSQLProductContext>();
            services.AddScoped<IAccountContext, MSSQLAccountContext>();
            services.AddScoped<ICategorieContext, MSSQLCategorieContext>();
            services.AddScoped<IKlantContext, MSSQLKlantContext>();
            services.AddScoped<IOrderContext, MSSQLOrderContext>();
            services.AddScoped<IWerknemerContext, MSSQLWerknemerContext>();
            services.AddScoped<IBestellingContext, MSSQLBestellingContext>();
            services.AddScoped<IFiliaalContext, MSSQLFiliaalContext>();

            // Repositories
            services.AddScoped<AccountRepository>();
            services.AddScoped<CategorieRepository>();
            services.AddScoped<KlantRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<WerknemerRepository>();
            services.AddScoped<BestellingRepository>();
            services.AddScoped<FiliaalRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
