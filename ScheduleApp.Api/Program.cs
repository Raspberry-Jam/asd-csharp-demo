using Microsoft.EntityFrameworkCore;
using ScheduleApp.Api.Infrastructure;
using ScheduleApp.Api.Models;
using ScheduleDbContext = ScheduleApp.Api.Infrastructure.ScheduleDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IScheduleDbContext, ScheduleDbContext>(options => 
    options
        .UseSqlite(connectionString)
        .UseLazyLoadingProxies() // Automatically retrieve entity relationships upon access
        .LogTo(Console.WriteLine, LogLevel.Information) // Log SQL queries to console
        .EnableSensitiveDataLogging() // Show SQL query values in logs
);

var app = builder.Build();

// Seed the database if no rows currently exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IScheduleDbContext>();
    if (!await db.Events.AnyAsync())
    {
        var newEvent = new Event
        {
            Name = "My first event",
            DateStart = DateTime.Now,
            DateEnd = DateTime.Now.AddDays(7),
            HourMask = 0b01010101
        };
        db.Events.Add(newEvent);
        await db.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();