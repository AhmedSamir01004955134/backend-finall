using FinallShope.Bl.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinallShope.Bl.Repository;
using FinallShope.Bl.Intarface;

namespace FinallShope
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

            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinallShope", Version = "v1" });
            });
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddScoped<IcategoryRepo,CategoryRepo>();
            services.AddScoped<IshopeRep,ShopeRepo>();
            services.AddScoped<IitemPhtoRepo, ItemPhtoRepo>();
            services.AddScoped<Iitem, ItemRepo>();
            services.AddScoped<IdescraptionItemRepo, DescraptionItemRepo>();
           

            services.AddDbContext<FinallShopeContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FinallShopeContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinallShope v1"));
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
