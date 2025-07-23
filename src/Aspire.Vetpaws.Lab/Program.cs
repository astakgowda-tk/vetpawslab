using Aspire.Vetpaws.Lab.AutoMapping;
using Aspire.Vetpaws.Lab.Data.Bill;
using Aspire.Vetpaws.Lab.Service.Login;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

IMapper mapper = new MapperConfiguration(cfg =>
{
    cfg = AutoMapperConfig.InitializeMapper(cfg);
}, loggerFactory).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<ILoginService, LoginService>();
builder.Services.AddSingleton<IItemPriceData, ItemPriceData>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8); // Set session timeout to 8 hours
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
    options.Cookie.IsEssential = true; // Make the session cookie essential for the application
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Redirect to login page if not authenticated
        options.AccessDeniedPath = "/Home/AccessDenied"; // Redirect to access denied page if user does not have permission
        options.ExpireTimeSpan = TimeSpan.FromHours(8); // Set cookie expiration time to 8 hours
        options.SlidingExpiration = true;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
