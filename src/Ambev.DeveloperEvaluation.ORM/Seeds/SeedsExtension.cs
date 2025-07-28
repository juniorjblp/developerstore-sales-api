using Ambev.DeveloperEvaluation.ORM.Seeds.Branches;
using Ambev.DeveloperEvaluation.ORM.Seeds.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ambev.DeveloperEvaluation.ORM.Seeds
{
    /// <summary>
    /// This class is responsible for configuring the database seeding process.
    /// </summary>
    public static class SeedsExtension
    {
        /// <summary>
        /// Configures the database seeding process.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <returns>The updated service collection with seeding services registered.</returns>
        public static IServiceCollection AddSeedsConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IProductSeeder, ProductSeeder>();
            services.AddTransient<IBranchSeeder, BranchSeeder>();

            return services;
        }

        /// <summary>
        /// Seeds product data if enabled in the configuration.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static async Task SeedProductIfEnabledAsync(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

            if (config.GetValue<bool>("SeedProductData"))
            {
                using var scope = app.ApplicationServices.CreateScope();
                var seeder = scope.ServiceProvider.GetRequiredService<IProductSeeder>();
                await seeder.SeedAsync(40);
            }
        }

        /// <summary>
        /// Seeds product data if enabled in the configuration.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static async Task SeedBranchIfEnabledAsync(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

            if (config.GetValue<bool>("SeedBranchData"))
            {
                using var scope = app.ApplicationServices.CreateScope();
                var seeder = scope.ServiceProvider.GetRequiredService<IBranchSeeder>();
                await seeder.SeedAsync(5);
            }
        }

        /// <summary>
        /// Executes database migration if enabled in the configuration.
        /// </summary>
        /// <param name="app"></param>
        public static void ExecuteMigrationIfEnabled(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

            if (config.GetValue<bool>("ExecuteMigration"))
            {
                using var scope = app.ApplicationServices.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
