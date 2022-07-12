using TaskManager.Models;
using TaskManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;


[ApiController]
[Route("[controller]")]
public class TaskProcessorController : ControllerBase
{
    public TaskProcessorController()
    {

    }


    // PUT
    [HttpPut("{id}")]
    public IActionResult Process(int id, Models.Task task)
    {
        if (id != task.Id)
            return BadRequest();

        var existingTask = TaskService.Get(id);
        if (existingTask is null)
            return NotFound();

        TaskService.Update(task);

        return NoContent();
    }
}
