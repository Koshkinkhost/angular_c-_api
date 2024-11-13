using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.EntityFrameworkCore; // Ќе забудьте добавить эту директиву
using nginx_project.models;
using Microsoft.IdentityModel.Tokens; // ƒобавьте пространство имен вашего контекста базы данных

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// –егистраци€ контекста базы данных
builder.Services.AddDbContext<nginx_project.models.AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // »спользуем builder.Configuration

// –егистраци€ контроллеров с представлени€ми
builder.Services.AddControllersWithViews(); // »справлено на builder.Services
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        // строка, представл€юща€ издател€
        ValidIssuer = AuthOptions.ISSUER,
        // будет ли валидироватьс€ потребитель токена
        ValidateAudience = true,
        // установка потребител€ токена
        ValidAudience = AuthOptions.AUDIENCE,
        // будет ли валидироватьс€ врем€ существовани€
        ValidateLifetime = true,
        // установка ключа безопасности
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // валидаци€ ключа безопасности
        ValidateIssuerSigningKey = true,

    };
});

var app = builder.Build();
app.UseAuthentication();
// Configure the HTTP request pipeline.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath)),
    RequestPath = ""
});

app.Run();
