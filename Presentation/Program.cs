using Data.Context;
using MySql.EntityFrameworkCore.Extensions;
using Application;
using Microsoft.AspNetCore.Identity;
using Data.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMySQLServer<EmployeeAppDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddServices();
builder.Services.AddEServices();
builder.Services.AddAServices();

builder.Services.AddMServices();

builder.Services.AddIdentity<MyUser, IdentityRole>(
    options=>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 7;
        options.Password.RequireNonAlphanumeric = false;

        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.AllowedForNewUsers = true;

        options.SignIn.RequireConfirmedEmail = true;
    })
    .AddEntityFrameworkStores<EmployeeAppDbContext>()
    .AddDefaultTokenProviders();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddServices();
   


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();




app.Run();
