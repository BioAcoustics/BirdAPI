using BirdAPI.ApiService.BackgroundServices;
using BirdAPI.ApiService.Database;
using Neo4j.Berries.OGM;
using BirdAPI.ApiService.Controllers;
using Microsoft.EntityFrameworkCore; // Stellen Sie sicher, dass der Namespace korrekt importiert wird

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddControllers(); // Diese Zeile registriert alle Controller
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "BirdAPI.ApiService", Version = "v1" });
});
builder.Services.AddHttpClient();
builder.Services.AddHostedService<XenoCantoFetcher>();

builder.Services.AddDbContext<ApplicationDBContext>();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapControllers(); // Diese Zeile registriert alle Endpunkte aus den Controllern

app.MapDefaultEndpoints();

app.Run();