using fiotec_viaCep.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adiciona a documentação do Swagger via extensão
builder.Services.AddSwaggerDocumentation();

// Opcional: habilitar CORS se precisar
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", builder =>
//     {
//         builder.AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//     });
// });

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

// app.UseHttpsRedirection(); // habilite se quiser HTTPS

// app.UseCors("AllowAll"); // se habilitar CORS

app.UseAuthorization();

app.MapControllers();

app.Run();