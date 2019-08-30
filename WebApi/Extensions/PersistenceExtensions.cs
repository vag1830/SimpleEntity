using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Persistence;
using Infrastucture.InMemoryPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("InMemoryDbConnectionString");

            services.AddDbContext<SimpleEntityContext>(builder => builder.UseInMemoryDatabase(connectionString));
            services.AddScoped<ISimpleEntityRepository, InMemorySimpleEntityRepository>();

           // services.AddScoped<ISimpleEntityRepository, FakeSimpleEntityRepository>();

            return services;
        }
    }
}
