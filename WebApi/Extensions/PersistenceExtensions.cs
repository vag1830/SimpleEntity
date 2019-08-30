﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Persistence;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // var connectionString = configuration.GetConnectionString("InMemoryDbConnectionString");
            var connectionString = configuration.GetConnectionString("SQLLiteConnectionString");

            //services.AddDbContext<SimpleEntityContext>(builder => builder.UseInMemoryDatabase(connectionString));
            services.AddDbContext<SimpleEntityContext>(builder => builder.UseSqlServer(connectionString));

            services.AddScoped<ISimpleEntityRepository, SqlLiteSimpleEntityRepository>();

           // services.AddScoped<ISimpleEntityRepository, FakeSimpleEntityRepository>();

            return services;
        }
    }
}
