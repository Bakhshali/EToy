using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public static class MVCService
    {
        public static IServiceCollection AddMyMvcServices(this IServiceCollection services)
        {
            services.AddMvc();
            return services;
        }
    }
}
