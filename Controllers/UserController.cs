using BudgetTracker.Models;
using BudgetTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll() => await _userService.GetAllAsync();

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _userService.GetAsync(id);

        if (user is null)
            return NotFound();

        return user;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        var newUser = await _userService.AddAsync(user);
        if (newUser is null)
            return BadRequest();
        return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = await _userService.GetAsync(id);
        if (existingUser is null)
            return NotFound();

        await _userService.UpdateAsync(user);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.GetAsync(id);

        if (user is null)
            return NotFound();

        await _userService.DeleteAsync(id);

        return NoContent();
    }
}
