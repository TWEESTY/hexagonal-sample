using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Application.Services;
using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Application.Ports.Output;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyApp.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
        }
        
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBookManagementService, BookManagementService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            // Get all interfaces which implement IRepository
            Type type = typeof(IRepository);
            IList<Type> interfacesIRepository = type.Assembly.GetTypes().Where(c => type.IsAssignableFrom(c) && c != type && c.IsInterface).ToList();

            // For each assembly, add implementation of interfaces which implement IRepository
            AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(assembly =>
            {
                List<Type> implementations = assembly.GetTypes().Where(type => interfacesIRepository.Any(interf => interf.IsAssignableFrom(type)) && type.IsClass).ToList();
                implementations.ForEach(implementation =>
                            services.AddTransient(implementation.GetInterfaces().First(interf => type.IsAssignableFrom(interf)), implementation)
                );
            });
        }
    }
}
