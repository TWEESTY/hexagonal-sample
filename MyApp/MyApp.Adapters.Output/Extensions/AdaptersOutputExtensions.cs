using Microsoft.Extensions.DependencyInjection;
using MyApp.Adapters.Output.Context;

namespace MyApp.Adapters.Output.Extensions
{
    public static class AdaptersOutputExtensions
    {
        public static void AddAdaptersOutput(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>();
        }
    }
}
