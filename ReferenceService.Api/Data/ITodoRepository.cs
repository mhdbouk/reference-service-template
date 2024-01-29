using ReferenceService.Api.Entities;

namespace ReferenceService.Api.Data;

public interface ITodoRepository
{
    Task<TodoItem> AddAsync(TodoItem entity);
    Task<TodoItem?> GetAsync(int id);
    Task<IEnumerable<TodoItem>> GetAsync();
    Task<TodoItem> UpdateAsync(TodoItem entity);
    Task DeleteAsync(int id);
}
