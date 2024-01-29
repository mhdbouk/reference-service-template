using Microsoft.EntityFrameworkCore;

namespace ReferenceService.Api.Data.Sql;

public class ReferenceServiceDbContext : DbContext
{
    public DbSet<TodoSqlModel> Todos => Set<TodoSqlModel>();
}
