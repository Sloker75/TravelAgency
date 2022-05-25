using BLL.Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DLL.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelAgencyContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelAgencyContextConnection' not found.");

builder.Services.AddDbContext<TravelAgencyContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TravelAgencyContext>();;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var identityBuilder = builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true);

BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder);
travelAgency.Infrastructure.Configuration.ConfigurationService(identityBuilder);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
