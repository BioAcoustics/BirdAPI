using BirdAPI.ApiService.BackgroundServices;
using BirdAPI.ApiService.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; // Stellen Sie sicher, dass der Namespace korrekt importiert wird

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

var Configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

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