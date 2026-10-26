using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication.Domain;
using WebApplication.Infrastructure;
using WebApplication.Domain.Repositories.Abstract;
using WebApplication.Domain.Repositories.EntityFramework;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
AppConfig appConfig = configuration.GetSection("Project").Get<AppConfig>()!;

// Подключение SQLite (вместо SqlServer)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(appConfig.database.connectionString)
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddErrorDescriber<RussianIdentityErrorDescriber>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

// Регистрация репозиториев (добавим позже)
builder.Services.AddTransient<IDistrictRepository, EFDistrictRepository>();
builder.Services.AddTransient<IShawarmaPlaceRepository, EFShawarmaPlaceRepository>();
builder.Services.AddTransient<IReviewRepository, EFReviewRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();