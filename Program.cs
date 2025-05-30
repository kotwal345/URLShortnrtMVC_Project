using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using URLShortnerMVC_Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//  Add database context and SQL Server provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Add controllers with views (MVC)
builder.Services.AddControllersWithViews();

//  Add session-related services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//  Use static files (css, js, images)
app.UseStaticFiles();

//  Middleware pipeline
app.UseRouting();

//  Enable session before authorization
app.UseSession();

//  If you later use Identity, you can enable authentication/authorization
app.UseAuthorization();

//  Define default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
