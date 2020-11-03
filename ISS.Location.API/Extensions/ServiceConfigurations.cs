using ISS.Location.API.Contracts;
using ISS.Location.API.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ISS.Location.API.Extensions
{
    public static class ServiceConfigurations
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
