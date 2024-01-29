using System.Text.Json.Serialization;

namespace ReferenceService.Api.Data.NoSql.Models;

public abstract class CosmosModel
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("partitionKey")]
    public required string PartitionKey { get; set; }
}
