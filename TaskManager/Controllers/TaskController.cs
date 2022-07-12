using TaskManager.Models;
using TaskManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    public TaskController()
    {

    }

    // GET
    [HttpGet]
    public ActionResult<List<Models.Task>> GetAll() =>
        TaskService.GetAll();

    // GET one
    [HttpGet("{id}")]
    public ActionResult<Models.Task> Get(int id)
    {
        var task = TaskService.Get(id);

        if(task == null)
            return NotFound();

        return task;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Models.Task task)
    {
        TaskService.Add(task);
        return CreatedAtAction(nameof(Create), new { id = task.Id }, task);
    }
}