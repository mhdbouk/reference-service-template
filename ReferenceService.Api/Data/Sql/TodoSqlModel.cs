using ReferenceService.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReferenceService.Api.Data.Sql;

public class TodoSqlModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Title { get; set; }
    
    public bool IsCompleted { get; set; }
}

public static class TodoSqlModelExtensions
{
    public static TodoItem ToEntity(this TodoSqlModel model)
    {
        return new TodoItem
        {
            Id = model.Id,
            Title = model.Title,
            IsCompleted = model.IsCompleted
        };
    }
    
    public static TodoSqlModel ToSqlModel(this TodoItem entity)
    {
        return new TodoSqlModel
        {
            Id = entity.Id,
            Title = entity.Title,
            IsCompleted = entity.IsCompleted
        };
    }
}
