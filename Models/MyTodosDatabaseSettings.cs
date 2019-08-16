namespace MyTodosAPI.Models {
  public class MyTodosDatabaseSettings : IMyTodosDatabaseSettings {
    public string TodosCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IMyTodosDatabaseSettings {
    string TodosCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}