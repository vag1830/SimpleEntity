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
using WebApi.UseCases.Authenticate;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;
using WebApi.UseCases.Register;

namespace WebApi.Extensions
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<GetAllOutputHandler, GetAllOutputHandler>();
            services.AddScoped<IGetAllOutputHandler, GetAllOutputHandler>(provider => provider.GetRequiredService<GetAllOutputHandler>());
            services.AddScoped<IGetAllUseCase, GetAllUseCase>();

            services.AddScoped<GetByIdOutputHandler, GetByIdOutputHandler>();
            services.AddScoped<IGetByIdOutputHandler, GetByIdOutputHandler>(provider => provider.GetRequiredService<GetByIdOutputHandler>());
            services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();

            services.AddScoped<AuthenticateOutputHandler, AuthenticateOutputHandler>();
            services.AddScoped<IAuthenticateOutputHandler, AuthenticateOutputHandler>(provider => provider.GetRequiredService<AuthenticateOutputHandler>());
            services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();

            services.AddScoped<RegisterOutputHandler, RegisterOutputHandler>();
            services.AddScoped<IRegisterOutputHandler, RegisterOutputHandler>(provider => provider.GetRequiredService<RegisterOutputHandler>());
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();

            return services;
        }

    }
}
