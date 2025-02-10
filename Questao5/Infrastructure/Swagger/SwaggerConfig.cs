using Microsoft.OpenApi.Models;

namespace Questao5.Infrastructure.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Contas",
                    Version = "v1",
                    Description = "API para gerenciamento de contas bancárias e movimentações.",
                });

                // Adiciona suporte para objetos complexos
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return services;
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conta Corrente API v1");
                c.RoutePrefix = string.Empty; // Deixa o Swagger na URL raiz
            });
        }
    }
}
