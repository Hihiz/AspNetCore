using Core.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionLocalDb"]);
});

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionLocalDb"]);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllers();

//app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.UseStaticFiles();

app.UseAuthorization();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
SeedData.SeedDatabase(context);

app.Run();
