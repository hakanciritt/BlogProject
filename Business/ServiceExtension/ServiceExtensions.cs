using AutoMapper;
using Business.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Business.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile>() { new MappingProfile(), new WebMappingProfile() });
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
