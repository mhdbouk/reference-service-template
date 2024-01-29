using ReferenceService.Api.Data;
using ReferenceService.Api.Entities;

namespace ReferenceService.Api.Endpoints;

public static class TodoEndpoints
{
    public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/todo", async (ITodoRepository repository)
            => await repository.GetAsync());

        endpoints.MapGet("/todo/{id:int}", async (int id, ITodoRepository repository) =>
            await repository.GetAsync(id)
                is { } todo
                ? Results.Ok(todo)
                : Results.NotFound()
        );

        endpoints.MapPost("/todo", async (TodoItem todo, ITodoRepository repository) =>
        {
            await repository.AddAsync(todo);

            return Results.Ok(todo);
        });

        return endpoints;
    }
}
