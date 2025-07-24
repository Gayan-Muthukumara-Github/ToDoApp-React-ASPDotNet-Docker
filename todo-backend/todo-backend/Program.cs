using Microsoft.EntityFrameworkCore;
using todo_backend.Data;
using System;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000") // Allow frontend origin
            .AllowAnyMethod()
            .AllowAnyHeader());
});


// Configure Kestrel to listen on http://0.0.0.0:5000
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add services to the container.

builder.Services.AddControllers();

// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Optional: comment out HTTPS redirection if you are not using HTTPS in container
// app.UseHttpsRedirection();

// Enable CORS middleware
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

// Auto-migrate database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
