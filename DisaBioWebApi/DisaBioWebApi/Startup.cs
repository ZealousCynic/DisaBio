using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using DisaBioModel.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DisaBioWebApi
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
            services.AddScoped<ICinemaRepository<Cinema>, CinemaRepository>();
            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IRepository<Location>, LocationRepository>();
            services.AddScoped<IRepository<Movie>, MovieRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Star>, StarRepository>();
            services.AddScoped<IRepository<Ticket>, TicketRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddControllers();

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

            app.UseWebSockets();

            app.UseWebSocketHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
