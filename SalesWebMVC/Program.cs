using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SalesWebMVCContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.");

builder.Services.AddDbContext<SalesWebMVCContext>(options => options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly("SalesWebMVC")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Serviços
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Executa o Seed
using (var scope = app.Services.CreateScope())
{
    SeedingService seedingService =
        scope.ServiceProvider.GetRequiredService<SeedingService>();

    seedingService.Seed();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
