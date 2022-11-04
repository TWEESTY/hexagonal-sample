using Microsoft.Extensions.DependencyInjection;
using MyApp.Adapters.Input.Rest.AutoMapper;

namespace MyApp.Adapters.Input.Rest.Extensions
{
    public static class AdaptersInputExtensions
    {
        public static void AddAdaptersInput(this IServiceCollection services)
        {
            services.AddAutoMapper(new[] { typeof(BookProfile), typeof(StoreProfile) });        
        }
    }
}
