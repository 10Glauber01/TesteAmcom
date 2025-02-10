using MediatR;
using Microsoft.Data.Sqlite;
using System.Data;
using Questao5.Infrastructure.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");


builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IDbConnection>(sp => new SqliteConnection("Data Source=contas.db"));
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Contas V1");
        c.RoutePrefix = string.Empty; 
    });
}


app.UseHttpsRedirection(); 
app.MapControllers();


try
{
    app.RunAsync().Wait();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao iniciar a API: {ex.Message}");
}