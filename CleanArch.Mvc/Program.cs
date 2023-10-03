using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Ioc;
using CleanArch.Mvc.Configurations;
using CleanArch.Mvc.Utility;
using FluentAssertions.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Stripe;

var builder = WebApplication.CreateBuilder(args);



var connectionStringNew = builder.Configuration.GetConnectionString("myconnectionNew");
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseSqlServer(connectionStringNew));



builder.Services.AddMediatR(typeof(DependencyContainer));

builder.Services.RegisterAutoMapper();


RegisterServices(builder.Services);

builder.Services.AddRazorPages();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()       //options => options.SignIn.RequireConfirmedAccount = true
    .AddEntityFrameworkStores<UniversityDBContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddControllersWithViews();


// must add after ( identity user)
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});



// add session for shoppingcart count
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "286516060610620";
    option.AppSecret = "6094ef6dc8977cbfac8b65799d5affb5";
});

builder.Services.AddAuthentication().AddMicrosoftAccount(option => {
    option.ClientId = "35b4966e-63bc-4bcf-9419-f6232df41c67";
    option.ClientSecret = "~M~8Q~5W1M5De04pW0hgd1A2GjQR.poX7g3dCbxU";
});


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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


static void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}