using Core.Infrastructure;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionLocalDb"]);
});

var app = builder.Build();

const string BASEURL = "/api/products";

app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, ApplicationContext data) =>
{
    string id = context.Request.RouteValues["id"] as string;

    if (id != null)
    {
        Product product = data.Products.Find(long.Parse(id));

        if (product == null)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(product));
        }
    }
});

app.MapGet(BASEURL, async (HttpContext context, ApplicationContext data) =>
{
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products));
});

app.MapPost(BASEURL, async (HttpContext context, ApplicationContext data) =>
{
    Product product = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);

    if (product != null)
    {
        await data.AddAsync(product);
        await data.SaveChangesAsync();
        context.Response.StatusCode = StatusCodes.Status200OK;
    }

    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products));
});

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
SeedData.SeedDatabase(context);

app.MapGet("/", () => "Hello World!");

app.Run();

