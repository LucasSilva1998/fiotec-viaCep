using fiotec_viaCep.API.Extensions;
using fiotec_viaCep.Application.Extensions;
using fiotec_viaCep.Infra.Services.Interface;
using fiotec_viaCep.Infra.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Application Services
builder.Services.AddApplicationServices();

// Infra HTTP externo (ViaCep)
builder.Services.AddHttpClient<IViaCepService, ViaCepService>();

// Adiciona a documentação do Swagger via extensão
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiotec - ViaCEP API v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz: http://localhost:5000/
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();