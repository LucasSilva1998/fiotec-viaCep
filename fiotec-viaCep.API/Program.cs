using fiotec_viaCep.API.Extensions;
using fiotec_viaCep.API.Middlewares;
using fiotec_viaCep.Application.Extensions;
using fiotec_viaCep.Infra.Services.Interface;
using fiotec_viaCep.Infra.Services.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Application Services 
builder.Services.AddApplicationServices();

// Configura��es ViaCEP a partir do appsettings.json
var viaCepSettings = builder.Configuration.GetSection("ViaCepSettings");

// HttpClient para o servi�o ViaCEP com Timeout e Retry 
builder.Services.AddHttpClient<IViaCepService, ViaCepService>(client =>
{
    client.BaseAddress = new Uri(viaCepSettings["BaseUrl"]);
    client.Timeout = TimeSpan.FromSeconds(int.Parse(viaCepSettings["TimeoutSeconds"]));
})
.AddPolicyHandler(HttpPolicyExtensions
    .HandleTransientHttpError() 
    .WaitAndRetryAsync(
        int.Parse(viaCepSettings["RetryCount"]),
        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
    ));

// Documenta��o do Swagger
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiotec - ViaCEP API v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
