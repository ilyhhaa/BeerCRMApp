using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBeerCRMApp.Areas.Identity.Data;
using MyBeerCRMApp.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyBeerCRMAppAuthDBContextConnection") ?? throw new InvalidOperationException("Connection string 'MyBeerCRMAppAuthDBContextConnection' not found.");

builder.Services.AddDbContext<MyBeerCRMAppAuthDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyBeerCRMAppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MyBeerCRMAppAuthDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options=>options.Password.RequireUppercase=false); //���� ����� ������� � �������� ����� ������� �������� ������ � ������ ���������� ���������� ����(���� ����������� ���-�� �������� ����� - 6 (���)
                                                                                               //�� ���� �� ���������� ����� ����������� ��� ��� ����� ������ �����������!
                                                                                               //����� ��� ��������, �� � ������, � ����� ������������� � ��������� �������� ��� ����������� ������ 
builder.Services.Configure<IdentityOptions>(options => options.Password.RequireNonAlphanumeric = false); //�������� ����� ���������� ��� ���� �����, ��� � ��������� ���� ���������� ��� �� ���������-�������� �������� RequireNonAlphanumeric ���� ����� ��� ����, �� �� �������� �� ����� ��������� 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); 
app.Run();
