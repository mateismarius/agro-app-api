using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring Swagger documentation for an ASP.NET Core API.
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Adds Swagger documentation services to the specified service collection.
        /// </summary>
        /// <param name="services">The service collection to which to add the Swagger documentation services.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // Configure the JWT Bearer authentication scheme for Swagger.
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorisation",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    securitySchema, new[] {"Bearer"}
                }
            };

                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }

        /// <summary>
        /// Configures Swagger and Swagger UI middleware to generate and serve Swagger documentation for the API.
        /// </summary>
        /// <param name="app">The application builder to which to add the Swagger middleware.</param>
        /// <returns>The modified application builder.</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            // Enable the Swagger and Swagger UI middleware.
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }


}
