using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionLocalDb"]);
});


builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

app.MapControllers();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
SeedData.SeedDatabase(context);

app.MapGet("/", () => "Hello World!");

app.Run();

