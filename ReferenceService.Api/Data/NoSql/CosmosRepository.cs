using Microsoft.Azure.Cosmos;
using ReferenceService.Api.Data.NoSql.Models;

namespace ReferenceService.Api.Data.NoSql;

public abstract class CosmosRepository<T> where T : CosmosModel
{
    protected readonly Container Container;
    protected CosmosRepository(CosmosClient client, string databaseId, string containerId)
    {
        Container = client.GetContainer(databaseId, containerId);
    }
}
