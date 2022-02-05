using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUI.ApiServices;
using Microsoft.Extensions.DependencyInjection;

namespace BlogUI.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHttpClientConfiguration(this IServiceCollection services, string apiUrl)
        {
            services.AddHttpClient<BlogApiService>(options => { options.BaseAddress = new Uri(apiUrl); });

        }
    }
}
