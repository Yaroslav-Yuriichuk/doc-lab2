using BLL.Services.Interfaces;
using DLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabDoc2MVC.Controllers;

public class MessagesController : Controller
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<IActionResult> GetAll()
    {
        return View(await _messageService.GetAllAsync());
    }

    public async Task<IActionResult> GetById(int id)
    {
        return View(await _messageService.GetByIdAsync(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Message message)
    {
        return View(await _messageService.CreateAsync(message));
    }

    public async Task<IActionResult> Generate()
    {
        return View(await _messageService.GenerateAndSave());
    }

    public async Task<IActionResult> Load()
    {
        return View(await _messageService.LoadToDatabase());
    }
}