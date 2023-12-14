using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestión de Usuarios API",
        Version = "v1",
        Description="API que permite la gestión de operaciones relacionadas con usuarios.Proporciona endpoints para crear y obtener información de usuarios. La documentación de la API incluye información detallada sobre estos endpoints, como sus parámetros de entrada y respuestas esperadas.",
        Contact = new OpenApiContact
        {
            Name = "Herwin Mendez"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",  "Gestión de usuarios API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
