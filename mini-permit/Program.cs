using Microsoft.EntityFrameworkCore;
using MiniPermit.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllersWithViews();

// Add MySQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mini Permit API",
        Version = "v1",
        Description = "A simple ASP.NET Core 9 + MySQL + Swagger demo"
    });
});

// Enable global CORS for Swagger testing
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");

// Enable Swagger always (not just in development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mini Permit API V1");
    c.RoutePrefix = "swagger"; // accessible at /swagger
});

// Optional: Disable HTTPS redirection to avoid localhost SSL error
// Comment out the next line if HTTPS already works
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
