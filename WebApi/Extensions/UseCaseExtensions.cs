﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Boundaries.UseCases.GetById;
using Core.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

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

            return services;
        }

    }
}
