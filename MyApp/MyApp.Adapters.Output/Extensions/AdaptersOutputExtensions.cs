using Microsoft.Extensions.DependencyInjection;
using MyApp.Adapters.Output.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
