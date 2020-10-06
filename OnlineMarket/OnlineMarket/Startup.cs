using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OnlineMarket.Data;


namespace OnlineMarket
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<NkTechSolutionContext>(cfg =>
          { cfg.UseSqlServer(_Configuration.GetConnectionString("NkTechSolutionsConnectionString"));
                });

            services.AddControllersWithViews();
            services.AddTransient<NkTechSolutionSeeder>();
            services.AddScoped<INkTechSolutionRepository, NkTechSolutionRepository>();

            //services.AddMvc()
            //  .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
          
            //aint sure if this will worrk
            services.AddControllersWithViews().
              AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                  options.JsonSerializerOptions.PropertyNamingPolicy = null;
              });
        }
      



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
