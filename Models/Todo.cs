using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MyTodosAPI.Models {
  public class Todo {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id { get; set; }
    
    [BsonRequired]
    [BsonRepresentation(BsonType.DateTime)]
    public long DateCreated { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.DateTime)]
    public long DateUpdated { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Description { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsComplete { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsArchived { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CreatedBy { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public long DateDue { get; set; }

  }
}