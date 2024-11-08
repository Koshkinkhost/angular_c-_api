using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore; // Не забудьте добавить эту директиву
using nginx_project.models; // Добавьте пространство имен вашего контекста базы данных

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Регистрация контекста базы данных
builder.Services.AddDbContext<nginx_project.models.AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Используем builder.Configuration

// Регистрация контроллеров с представлениями
builder.Services.AddControllersWithViews(); // Исправлено на builder.Services

var app = builder.Build();

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
