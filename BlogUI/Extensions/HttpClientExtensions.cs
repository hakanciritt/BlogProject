using BlogUI.ApiServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogUI.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHttpClientConfiguration(this IServiceCollection services, string apiUrl)
        {
            services.AddHttpClient<BlogApiService>(options => { options.BaseAddress = new Uri(apiUrl); });
            services.AddHttpClient<AboutApiService>(options => { options.BaseAddress = new Uri(apiUrl); });
            services.AddHttpClient<MessageApiService>(options => { options.BaseAddress = new Uri(apiUrl); });
            services.AddHttpClient<WriterApiService>(options => { options.BaseAddress = new Uri(apiUrl); });

        }
    }
}
