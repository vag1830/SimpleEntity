using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Persistence;
using Core.Application.UseCases;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

namespace WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();

            services.AddScoped<GetAllOutputHandler, GetAllOutputHandler>();
            services.AddScoped<IGetAllOutputHandler, GetAllOutputHandler>(x => x.GetRequiredService<GetAllOutputHandler>());
            services.AddScoped<IGetAllUseCase, GetAllUseCase>();
            services.AddScoped<ISimpleEntityRepository, FakeSimpleEntityRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
