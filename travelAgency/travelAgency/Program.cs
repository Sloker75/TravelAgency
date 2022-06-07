using BLL.Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DLL.Context;
using Microsoft.AspNetCore.Identity.UI.Services;
using travelAgency.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, services, configuration) => {
    configuration.WriteTo.File(builder.Environment.WebRootPath+"/Log.txt");
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var identityBuilder = builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true);

BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder);

builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();

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
