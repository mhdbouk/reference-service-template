using Microsoft.EntityFrameworkCore;
using ReferenceService.Api.Entities;

namespace ReferenceService.Api.Data.Sql;

public class TodoRepository : ITodoRepository
{
    private readonly ReferenceServiceDbContext _dbContext;
    public TodoRepository(ReferenceServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TodoItem> AddAsync(TodoItem entity)
    {
        await _dbContext.Todos.AddAsync(entity.ToSqlModel());
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<TodoItem> UpdateAsync(TodoItem entity)
    {
        _dbContext.Todos.Update(entity.ToSqlModel());
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task DeleteAsync(int id)
    {
        var todo = await _dbContext.Todos.FindAsync(id);
        if (todo is null)
        {
            return;
        }
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<TodoItem?> GetAsync(int id)
    {
        var sqlModel = await _dbContext.Todos.FindAsync(id);
        return sqlModel?.ToEntity();
    }
    
    public async Task<IEnumerable<TodoItem>> GetAsync()
    {
        var sql = await _dbContext.Todos.ToListAsync();
        return sql.Select(x => x.ToEntity());
    }
}
