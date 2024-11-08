using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore; // �� �������� �������� ��� ���������
using nginx_project.models; // �������� ������������ ���� ������ ��������� ���� ������

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ����������� ��������� ���� ������
builder.Services.AddDbContext<nginx_project.models.AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // ���������� builder.Configuration

// ����������� ������������ � ���������������
builder.Services.AddControllersWithViews(); // ���������� �� builder.Services

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// ������������� ������������� ��������� � �������������
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
