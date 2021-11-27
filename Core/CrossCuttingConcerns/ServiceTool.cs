﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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