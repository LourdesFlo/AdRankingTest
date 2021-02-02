using AutoMapper;
using coding_test_ranking.infrastructure.persistence;
using coding_test_ranking.Repositories;
using coding_test_ranking.Repositories.Interfaces;
using coding_test_ranking.Services;
using coding_test_ranking.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace coding_test_ranking
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting();

            services.AddSingleton<InMemoryPersistence>();

            services.AddScoped<ICalculateScoreService, CalculateScoreService>();
            services.AddScoped<IGetAdsService, GetAdsService>();
            services.AddScoped<IAdRepository, AdRepository>();
            services.AddAutoMapper(typeof(InMemoryPersistence), typeof(IAdRepository));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("/", "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
