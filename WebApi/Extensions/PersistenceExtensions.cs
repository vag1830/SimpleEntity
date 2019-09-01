using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Domain.Entities;
using Infrastructure;
using Infrastructure.DatabaseSeeds;
using Infrastructure.Persistense;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("InMemoryDbConnectionString");

            services.AddDbContext<SimpleEntityContext>(builder => builder.UseInMemoryDatabase(connectionString));
            services.AddScoped<ISimpleEntityRepository, InMemorySimpleEntityRepository>();

            return services;
        }

        public static IServiceCollection AddSqlLitePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLLiteConnectionString");

            services.AddDbContext<SimpleEntityContext>(builder => builder.UseSqlServer(connectionString));
            // services.AddDbContext<SimpleEntityUserContext>(builder => builder.UseSqlServer(connectionString));
            services.AddScoped<ISimpleEntityRepository, SqlLiteSimpleEntityRepository>();

            return services;
        }

        public static IServiceCollection AddDatabaseUserSeed(this IServiceCollection services)
        {
            services.AddScoped<SimpleEntityUserSeeder, SimpleEntityUserSeeder>();

            return services;
        }
    }
}
