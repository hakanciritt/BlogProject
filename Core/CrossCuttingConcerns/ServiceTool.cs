using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.CrossCuttingConcerns
{
    public class ServiceTool
    {
        public static IServiceProvider ServiceProvider;
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
