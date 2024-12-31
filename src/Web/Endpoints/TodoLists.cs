using DnaBrasilApi.Application.TodoLists.Commands.CreateTodoList;
using DnaBrasilApi.Application.TodoLists.Commands.DeleteTodoList;
using DnaBrasilApi.Application.TodoLists.Commands.UpdateTodoList;
using DnaBrasilApi.Application.TodoLists.Queries.GetTodos;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Lista de Tarefas
/// </summary>
public class TodoLists : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoLists)
            .MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Lista de Tarefas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Lista de Tarefas</param>
    /// <returns>Retorna Id da nova Lista de Tarefas</returns>
    public Task<int> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Lista de Tarefas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Lista de Tarefas</param>
    /// <param name="command">Objeto de alteração da Lista de Tarefas</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> UpdateTodoList(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    /// <summary>
    /// Endpoint para exclusão de Lista de Tarefas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão da Lista de Tarefas</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> DeleteTodoList(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Lista de Tarefas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Tarefas</returns>
    public Task<TodosVm> GetTodoLists(ISender sender)
    {
        return sender.Send(new GetTodosQuery());
    }
    #endregion
}
