using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Boundaries.Services;
using Application.Boundaries.UseCases.Authenticate;
using Application.Boundaries.UseCases.GetAll;
using Application.Boundaries.UseCases.GetById;
using Application.Boundaries.UseCases.Register;
using Application.UseCases;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;
using WebApi.UseCases.Authenticate;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;
using WebApi.UseCases.Register;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<TokenService, TokenService>();

            return services;
        }

    }
}
