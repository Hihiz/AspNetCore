using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionLocalDb"]);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

