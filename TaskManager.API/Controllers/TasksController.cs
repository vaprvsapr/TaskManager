using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.Tasks;
using TaskManager.API.Services;

namespace TaskManager.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TasksController(TaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDtoInfo>>> Get()
    {
        var tasks = await taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDtoInfo>> Get(int id)
    {
        var task = await taskService.GetTaskByIdAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDtoInfo>> Post([FromBody] TaskDtoCreate taskDtoCreate)
    {
        var createdTask = await taskService.CreateTaskAsync(taskDtoCreate);
        return Ok(createdTask);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskDtoInfo>> Put(int id, [FromBody] TaskDtoUpdate taskDtoUpdate)
    {
        var updatedTask = await taskService.UpdateTaskAsync(id, taskDtoUpdate);
        return Ok(updatedTask);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await taskService.DeleteTaskAsync(id);
        return Ok();
    }

}