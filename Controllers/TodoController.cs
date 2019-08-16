using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTodosAPI.Models;

namespace MyTodosAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase {
    private readonly TodoContext _context;

    public TodoController(TodoContext context) {
      _context = context;

      if (_context.TodoItems.Count() == 0) {
        // Create a new TodoItem if collection is empty, which means you can't delete all TodoItems.
        _context.TodoItems.Add(new TodoItem { Name = "Item1" });
        _context.SaveChanges();
      }
    }

    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems() {
        return await _context.TodoItems.ToListAsync();
    }

    // GET: api/todo/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(long id) {
      var todoItem = await _context.TodoItems.FindAsync(id);

      if (todoItem == null) {
        return NotFound();
      }

      return todoItem;
    }

    // POST: api/todo
    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item) {
      _context.TodoItems.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTodoItem), new TodoItem{ Id = item.Id }, item);
    }
  }
}