using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DLL.Csv.Implementations;
using DLL.Csv.Interfaces;
using DLL.Db;
using DLL.Models;
using DLL.Repositories.Implementations;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDb>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddScoped<ICsvFileService<Message>, DefaultCsvFileService<Message>>();
builder.Services.AddScoped<IMessageRepository, MessageDbRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();