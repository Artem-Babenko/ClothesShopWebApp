
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using СlothesShopWebApp;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();
string connectioSring = builder.Configuration.GetConnectionString("DevConnection")!;
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectioSring));
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Name = "AuthenticationCookie";
    options.AccessDeniedPath = "/access-denied";
    options.LoginPath = "/login";
});
builder.Services.AddAuthorization();
builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization(); 
app.UseResponseCompression();

app.MapControllers();

app.Run();