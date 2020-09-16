using AppDDDProject.AppMvc.Models;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Handlers;
using AppDDDProject.Domain.Repositories;
using AppDDDProject.Infra.Context;
using AppDDDProject.Infra.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppDDDProject.AppMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClienteHandler, ClienteHandler>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppMvc.Models.Cliente, Domain.Commands.ClienteCommand>();
                cfg.CreateMap<AppMvc.Models.Cliente, Domain.Entities.Cliente>();
                cfg.CreateMap<Domain.Commands.ClienteCommand, AppMvc.Models.Cliente>();
                cfg.CreateMap<Domain.Entities.Cliente, AppMvc.Models.Cliente>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
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
