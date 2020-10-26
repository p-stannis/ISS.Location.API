using System.Reflection;
using ISS.Location.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISS.Location.API.Extensions
{
    public static class DatabaseConfigurations
    {
        public static void ConfigureDatabase(this IServiceCollection services,
            IConfiguration config)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(config["ConnectionStrings:Database"],
                   b => b.MigrationsAssembly(migrationsAssembly)));
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                appDbContext.Database.Migrate();
            }
        }
    }
}
