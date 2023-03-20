using AutoMapper;
using Domain.Model;
using Infrastructure.ClothesCategories.Profiles;
using Infrastructure.Genders.Profiles;
using Infrastructure.Industrials.Profiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using System.Reflection;

namespace Infrastructure.Services
{
    public static class MediatorService
    {
        public static IServiceCollection AddExtraServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
                c.AddProfile<GenderProfile>();
                c.AddProfile<IndustrialProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpContextAccessor();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            return services;
        }
    }
}
