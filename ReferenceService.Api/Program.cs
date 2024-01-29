#if (UseCosmosDb)
using Microsoft.Azure.Cosmos;
using ReferenceService.Api.Data;
#endif
#if (UseSqlServer)
using Microsoft.EntityFrameworkCore;
using ReferenceService.Api.Data.Sql;
using ReferenceService.Api.Data;
#endif
using ReferenceService.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

#if(UseSwagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endif

#if (UseSqlServer)
#region Sql Server Configuration

builder.Services.AddDbContext<ReferenceServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


builder.Services.AddScoped<ITodoRepository, ReferenceService.Api.Data.Sql.TodoRepository>();

#endregion
#endif
#if (UseCosmosDb)
#region CosmosDb Configuration

var cosmosClient = new CosmosClient(builder.Configuration.GetConnectionString("CosmosDbConnectionString"), new CosmosClientOptions
{
    SerializerOptions = new CosmosSerializationOptions
    {
        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
    },
    ConnectionMode = ConnectionMode.Direct,
    EnableContentResponseOnWrite = false
});

builder.Services.AddSingleton(cosmosClient);
builder.Services.AddScoped<ITodoRepository, ReferenceService.Api.Data.NoSql.TodoRepository>();

#endregion
#endif

var app = builder.Build();
#if (UseSwagger)
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseHttpsRedirection();

app.MapTodoEndpoints();

app.Run();