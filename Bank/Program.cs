using Application.Interfaces;
using Application.Services;
using Bank.CardSequrity;
using DataAccess.AppDbContext;
using DataAccess.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICardRepository, EFCardRepository>();
builder.Services.AddTransient<IOperationRepository, EFOperationRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IOperationService, OperationService>();
builder.Services.AddTransient<ICardMenuService, CardMenuService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ISecurityRetrieve, CardNumberCookie>();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Card}/{action=Login}/{id?}");

app.Run();
