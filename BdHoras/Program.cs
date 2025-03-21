using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BdHoras.Data;
using BdHoras.Repository;
using BdHoras.Services;
using BdHoras.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; //default: true
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ·ÈÌÛ˙¡…Õ”⁄‚ÍÓÙ˚¬ Œ‘€„ı√’Á« "; //permite espaÁos e acentos no UserName
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IGestoresService, GestoresService>();
//builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GestoresFilter>();
});



builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGestoresRepository, GestoresRepository>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
