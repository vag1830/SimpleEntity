using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistence;
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

        public static IServiceCollection AddIdentityAndAuthentication(this IServiceCollection services)
        {
            services.AddIdentity<SimpleEntityUser, IdentityRole>()
                .AddEntityFrameworkStores<SimpleEntityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://simpleEntity.com",
                    ValidIssuer = "https://simpleEntity.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asafekeyfromconfiguration"))
                };
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        context.Response.StatusCode = 401;
                    }

                    return Task.CompletedTask;
                };
            });

            return services;
        }
    }
}
