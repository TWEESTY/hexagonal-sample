using Microsoft.Extensions.DependencyInjection;
using MyApp.Adapters.Input.AutoMapper;

namespace MyApp.Adapters.Input.Extensions
{
    public static class AdaptersInputExtensions
    {
        public static void AddAdaptersInput(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookProfile));
        }
    }
}
