using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using ReferenceService.Api.Data.NoSql.Models;
using ReferenceService.Api.Entities;

namespace ReferenceService.Api.Data.NoSql;

public class TodoRepository : CosmosRepository<TodoCosmosModel>, ITodoRepository
{
    public TodoRepository(CosmosClient client) : base(client, "TodoDb", "Todos")
    {
    }
    public async Task<TodoItem> AddAsync(TodoItem entity)
    {
        await Container.CreateItemAsync(entity.ToCosmosModel());
        return entity;
    }

    public async Task<TodoItem?> GetAsync(int id)
    {
        var item = await Container.ReadItemAsync<TodoCosmosModel>(id.ToString(), new PartitionKey("TODO"));
        return item.Resource?.ToEntity();
    }
    public async Task<IEnumerable<TodoItem>> GetAsync()
    {
        var feedIterator = Container.GetItemLinqQueryable<TodoCosmosModel>()
                                    .ToFeedIterator();

        var results = new List<TodoItem>();
        while (feedIterator.HasMoreResults)
        {
            var response = await feedIterator.ReadNextAsync();
            results.AddRange(response.Select(x => x.ToEntity()));
        }

        return results;
    }
    public async Task<TodoItem> UpdateAsync(TodoItem entity)
    {
        await Container.UpsertItemAsync(entity.ToCosmosModel());
        return entity;
    }
    public Task DeleteAsync(int id)
        => Container.DeleteItemAsync<TodoCosmosModel>(id.ToString(), new PartitionKey("TODO"));
}
