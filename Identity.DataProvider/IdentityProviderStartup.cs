using IdentityServer4.Services;
using Inventory.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.DataProvider
{
    public class IdentityProviderStartup: IDataProviderStartup
    {
        /// <summary>
        /// Register Service Providers at Inversion Control Container 
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Registered Service Collection</returns>
        public  IServiceCollection AddDataProviders(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventSink, EventsSink>();

            var connectionString = configuration.GetConnectionString("IdentityDatabase");

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = "https://localhost:44309/login";
                options.UserInteraction.ErrorUrl = "https://localhost:44309/home/error";
                options.Events.RaiseErrorEvents = true;
            })
                .AddDeveloperSigningCredential()
                .AddTestUsers(Config.GetUsers())
                // this adds the config data from DB (clients, resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString);
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString);

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddAuthorizeInteractionResponseGenerator<CustomAuthorizeInteractionResponseGenerator>();

            return services;
        }
    }
}
