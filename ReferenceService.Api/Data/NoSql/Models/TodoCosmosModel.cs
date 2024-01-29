using ReferenceService.Api.Entities;

namespace ReferenceService.Api.Data.NoSql.Models;

public class TodoCosmosModel : CosmosModel
{
    public required string Title { get; set; }
    
    public bool IsCompleted { get; set; }
}

public static class TodoCosmosModelExtensions
{
    public static TodoItem ToEntity(this TodoCosmosModel model)
    {
        return new TodoItem
        {
            Id = int.Parse(model.Id),
            Title = model.Title,
            IsCompleted = model.IsCompleted
        };
    }
    
    public static TodoCosmosModel ToCosmosModel(this TodoItem entity)
    {
        return new TodoCosmosModel
        {
            Id = entity.Id.ToString(),
            PartitionKey = "TODO", // whatever for now 👻
            Title = entity.Title,
            IsCompleted = entity.IsCompleted
        };
    }
}