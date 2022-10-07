using Microsoft.Extensions.DependencyInjection;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Repositories;
using MyApp.Application.Ports.Output.Repositories;
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
