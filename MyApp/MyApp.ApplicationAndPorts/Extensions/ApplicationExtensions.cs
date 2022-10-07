using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Application.Services;
using MyApp.Application.Ports.Input.BookManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookManagementService, BookManagementService>();

        }
    }
}
