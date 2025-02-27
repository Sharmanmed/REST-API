using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private static List<TodoItem> _todoItems = new List<TodoItem>();
    private static int _nextId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll()
    {
        return Ok(_todoItems);
    }

    [HttpPost]
    public ActionResult<TodoItem> Create(TodoItem item)
    {
        item.Id = _nextId++;
        _todoItems.Add(item);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var item = _todoItems.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        _todoItems.Remove(item);
        return NoContent();
    }
}