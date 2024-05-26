using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace UserManagementAPI.Infrastructure.Extensions.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection builder)
        {
            builder.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Please type the word 'Bearer' followed by space and then JWT"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            new string[] {}
                    }
                });
                option.CustomSchemaIds(type => type.ToString());
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);

                option.IncludeXmlComments(xmlPath);
                option.ExampleFilters();
            });
            return builder;
        }
    }
}

