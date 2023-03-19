using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public static class DatabaseService
    {


        public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultString"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
                options.UseInternalServiceProvider(sp);
            });
            return services;
        }
    }
}
