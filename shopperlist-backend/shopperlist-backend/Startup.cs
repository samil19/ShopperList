using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using shopperlist_backend.BussinessLogic;
using shopperlist_backend.BussinessLogic.Interfaces;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.DataAccess.Repositories;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend
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

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "shopperlist_backend", Version = "v1" });
            });
            services.AddDbContext<shopperlistContext>(options => {
                options.UseSqlServer("server=.;database=shopperlist;trusted_connection=true;");
        });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IScaleRepository, ScaleRepository>();
            services.AddScoped<IScaleLogic, ScaleLogic>();
            services.AddScoped<IRawProductRepository, RawProductRepository>();
            services.AddScoped<IRawProductLogic, RawProductLogic>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandLogic, BrandLogic>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IShopLogic, ShopLogic>();
            services.AddScoped<IShopListRepository, ShopListRepository>();
            services.AddScoped<IShopListLogic, ShopListLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shopperlist_backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
