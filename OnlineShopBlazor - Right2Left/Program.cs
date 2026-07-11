using eShop.Application;
using eShop.Application.Dtos;

using eShop.Infrastructure;
using eShop.Infrastructure.Repository;


using OnlineShopBlazor.Components;
using OnlineShopBlazor.Validation;

using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//DataBase Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with DI (single registration)
//builder.Services.AddDbContext<OnlineShopContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContextFactory<OnlineShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

builder.Services.AddBlazorBootstrap();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RecoveryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ResetPasswordValidator>();
builder.Services.AddAuthentication("MyCookiesAuth")
    .AddCookie("MyCookiesAuth", options =>
    {
        options.Cookie.Name = "OnlineShop.Auth";
        options.LoginPath = "/login";
        options.AccessDeniedPath="/AccessDenied";
        options.ClaimsIssuer = "shop.niloofarpahlevan.com";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


builder.Services.ConfigureInfraServices();
builder.Services.ConfigureApplicationaServices();

builder.Services.AddRazorPages().WithRazorPagesRoot("/Razor Pages");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(eShop.Web.CustomerPanel.Pages.SearchProductComponent).Assembly)
    .AddInteractiveServerRenderMode();
app.UseRouting();
//-------------------Run razor pages
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseAntiforgery();
//-------------------
app.Run();
