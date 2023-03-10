using Core;
using Microsoft.Win32.SafeHandles;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch =>
{
    branch.Use(async (HttpContext context, Func<Task> next) =>
    {
        await context.Response.WriteAsync("branch middleware");
    });
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
