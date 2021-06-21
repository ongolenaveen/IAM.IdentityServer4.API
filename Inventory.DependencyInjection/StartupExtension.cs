using Inventory.Core;
using Identity.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inventory.Domain.Interfaces;
using Inventory.SqlDbProvider;

namespace Inventory.DependencyInjection
{
    public static class StartupExtension
    {
        public static void AddBindings(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IDataProviderStartup,IdentityProviderStartup>();
            services.AddScoped<IDataProviderStartup, InventoryProviderStartup>();
            services.AddScoped<ILoginService, LoginService>();
            var serviceProvider = services.BuildServiceProvider();
            var providers = serviceProvider.GetServices<IDataProviderStartup>();
            foreach(var provider in providers) {
                provider.AddDataProviders(services, config);
            }
        }
    }
}
