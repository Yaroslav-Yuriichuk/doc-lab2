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
        int? id = (await _messageService.CreateAsync(message))?.Id;

        if (id == null)
        {
            return View();
        }

        return Redirect($"/Messages/GetById?id={id}");
    }

    public async Task<IActionResult> Update(int id)
    {
        return View(await _messageService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, [FromForm] Message message)
    {
        if (id != message.Id)
        {
            return BadRequest("Ids don't match");
        }

        Message? updatedMessage = await _messageService.UpdateAsync(message);

        if (updatedMessage == null)
        {
            return BadRequest("Cannot update");
        }

        return Redirect($"/Messages/GetById?id={id}");
    }

    public async Task<IActionResult> Delete(int id)
    {
        Message? deletedMessage = await _messageService.DeleteAsync(id);
        return View(deletedMessage);
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