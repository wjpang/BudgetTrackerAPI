using BudgetTracker.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if (user is null)
            return NotFound();

        return user;
    }

    // POST action
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User user)
    {
        var newUser = UserService.Add(user);
        if (newUser is null)
            return BadRequest();
        return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
    }

    // PUT action
    [HttpPut("{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = UserService.Get(id);
        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var user = UserService.Get(id);

        if (user is null)
            return NotFound();

        UserService.Delete(id);

        return NoContent();
    }
}