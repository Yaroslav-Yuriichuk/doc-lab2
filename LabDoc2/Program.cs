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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDb>();
    db.Database.EnsureCreated();
}

#region Minimal API

app.MapGet("/", () => "Welcome to the app!");

#region Messages API

app.MapGet("/api/messages", async (IMessageService messageService) => await messageService.GetAllAsync());
app.MapGet("/api/messages/{id:int}", async (IMessageService messageService, int id) =>
{
    return await messageService.GetByIdAsync(id) is { } message
        ? Results.Ok(message)
        : Results.NotFound();
});

app.MapPost("/api/messages", async (IMessageService messageService, Message message) =>
{
    return await messageService.CreateAsync(message) is { } createdMessage
        ? Results.Created($"/messages/{message.Id}", createdMessage)
        : Results.BadRequest();
});

app.MapPut("/api/messages", async (IMessageService messageService, Message message) =>
{
    return await messageService.UpdateAsync(message) is { } updatedMessage
        ? Results.Ok(updatedMessage)
        : Results.NotFound();
});

app.MapDelete("/api/messages/{id:int}", async (IMessageService messageService, int id) =>
{
    return await messageService.DeleteAsync(id) is { } deletedMessage
        ? Results.Ok(deletedMessage)
        : Results.NotFound();
});

app.MapPost("/api/messages/generate", async (IMessageService messageService) => await messageService.GenerateAndSave());
app.MapPost("/api/messages/load", async (IMessageService messageService) => await messageService.LoadToDatabase());

#endregion

#endregion

app.Run();