using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBeerCRMApp.Areas.Identity.Data;
using MyBeerCRMApp.Data;
using MyBeerCRMApp.Models;
using TodoManager;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("MyBeerCRMAppAuthDBContextConnection") ?? throw new InvalidOperationException("Connection string 'MyBeerCRMAppAuthDBContextConnection' not found.");

builder.Services.AddDbContext<MyBeerCRMAppAuthDBContext>(options => options.UseSqlServer(connectionString));


string Connection =  builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDefaultIdentity<MyBeerCRMAppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MyBeerCRMAppAuthDBContext>();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Connection));

string TodoDBConnection = builder.Configuration.GetConnectionString("TodoDbConnection");

builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(TodoDBConnection));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.Configure<IdentityOptions>(options=>options.Password.RequireUppercase=false); //Если здесь сбегать в дифинишн можно увидеть свойства пароля и собсна обнаружить интересные вещи(типа минимальное кол-во символов будет - 6 (шок)
                                                                                               //Но если не устраивает можно закастомить как тут через ламбда експрешионс!
                                                                                               //Нужно еще написать, шо я сделал, я убрал необходимость в апперкейс символах для регистрации пароля 
builder.Services.Configure<IdentityOptions>(options => options.Password.RequireNonAlphanumeric = false); //Наверное стоит пробросить еще одну штуку, там в свойствах есть требование для не алфавитно-цифровых символов RequireNonAlphanumeric надо чтобы они были, но мы наверное от этого откажемся 

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
