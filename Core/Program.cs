using Core;
using Microsoft.Win32.SafeHandles;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    await context.Response.WriteAsync($"\nStatus code: {context.Response.StatusCode}");
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
