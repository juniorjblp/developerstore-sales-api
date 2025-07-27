using Microsoft.OpenApi.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// This class is responsible for configuring Swagger for the API.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Provides Swagger configuration for the API.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <returns>The updated service collection with seeding services registered.</returns>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Developer Sales API",
                    Version = "v1",
                    Description = "Sales manager API"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
    }
}
