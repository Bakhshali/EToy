using DataAccess.Persistence;
using Infrastructure.ImageServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public static class ServicesLifeSpan
    {
        public static IServiceCollection AddServicesLifeSpan(this IServiceCollection services)
        {
            services.AddTransient<IPersistence, Persistence>();
            return services;
        }


    }
}
