using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ListaTelefonica.Data;
using ListaTelefonica.Data.NHibernate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTelefonica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            NHSessionFactory.ConnectionString = Configuration.GetConnectionString("pg");
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWorkForNHibernate<>));
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes().Where(a => !a.IsAbstract && a.Namespace == "ListaTelefonica.Entity"))
            {
                services.AddTransient(item);
            }
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes().Where(a => !a.IsAbstract && a.Namespace == "ListaTelefonica.Repository"))
            {
                services.AddTransient(item);
            }





            if (true)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                .WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE")
                                .AllowAnyHeader();
                        });
                });

                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
                });

            }
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
