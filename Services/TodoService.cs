using MyTodosAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MyTodosAPI.Services {
  public class TodoService {
    private readonly IMongoCollection<Todo> _todos;

    public TodoService(IMyTodosDatabaseSettings settings) {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _todos = database.GetCollection<Todo>(settings.TodosCollectionName);
    }

    public List<Todo> Get() => _todos.Find(todo => true).ToList();

    public Todo Get(string id) => _todos.Find<Todo>(todo => todo.Id == id).FirstOrDefault();

    public Todo Create(Todo todo) {
      _todos.InsertOne(todo);
      return todo;
    }

    public void Update(string id, Todo todoIn) => _todos.ReplaceOne(todo => todo.Id == id, todoIn);

    public void Remove(Todo todoIn) => _todos.DeleteOne(todo => todo.Id == todoIn.Id);

    public void Remove(string id) => _todos.DeleteOne(todo => todo.Id == id);
  }
}