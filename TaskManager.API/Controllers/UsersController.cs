using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.Users;
using TaskManager.API.Services;
namespace TaskManager.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController(UserService userService) : ControllerBase
{
    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDtoInfo>>> Get()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDtoInfo>> Get(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDtoInfo>> Post([FromBody] UserDtoCreate userDtoCreate)
    {
        var createdUser = await userService.CreateUserAsync(userDtoCreate);
        return Ok(createdUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDtoInfo>> Put(int id, [FromBody] UserDtoUpdate userDtoUpdate)
    {
        var updatedUser = await userService.UpdateUserAsync(id, userDtoUpdate);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        await userService.DeleteUserAsync(id);
        return NoContent();
    }
}
