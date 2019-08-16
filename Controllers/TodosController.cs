using MyTodosAPI.Models;
using MyTodosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyTodosAPI.Controllers {
  
  [Route("api/[controller]")]
  [ApiController]
  public class TodosController : ControllerBase {
    private readonly TodoService _todoService;

    public TodosController(TodoService todoService) {
      _todoService = todoService;
    }

    // GET: api/todos
    [HttpGet]
    public ActionResult<List<Todo>> Get() => _todoService.Get();

    // GET: api/todos/{id}
    [HttpGet("{id:length(24)}", Name = "GetTodo")]
    public ActionResult<Todo> Get(string id) {
      var todo = _todoService.Get(id);

      if (todo == null) {
        return NotFound();
      }

      return todo;
    }

    // POST: api/todos
    [HttpPost("{id:length(24)}")]
    public ActionResult<Todo> Create(Todo todo) {
      _todoService.Create(todo);

      return CreatedAtRoute("GetBook", new { id = todo.Id.ToString() }, todo);
    }

    // PUT: api/todos/{id}
    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Todo todoIn) {
      var todo = _todoService.Get(id);

      if (todo == null) {
        return NotFound();
      }

      _todoService.Update(id, todoIn);
      
      return NoContent();
    }

    // DELETE: api/todos/{id}
    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id) {
      var todo = _todoService.Get(id);

      if (todo == null) {
        return NotFound();
      }

      _todoService.Remove(todo.Id);

      return NoContent();
    }
  }
}