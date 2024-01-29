namespace ReferenceService.Api.Entities;

public class TodoItem
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}