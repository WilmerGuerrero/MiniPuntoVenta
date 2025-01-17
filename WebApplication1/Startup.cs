using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.Services;

namespace WebApplication1
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
            services.AddTransient<CRUDcliente, CRUDcliente>();
            services.AddTransient<CRUDfactura, CRUDfactura>();
            services.AddTransient<CRUDproductos, CRUDproductos>();
            services.AddTransient<CRUDProductoFacturado, CRUDProductoFacturado>();
            services.AddTransient<CRUDPuntoVenta, CRUDPuntoVenta>();
            services.AddCors(Cors => Cors.AddPolicy("AllowAllOrigin", builder =>
            {
                builder.AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader();
            }));
            services.AddDbContext<PuntoVentadbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAllOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
