using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.TodoItems.Commands.CreateTodoItem;
using DnaBrasilApi.Application.TodoItems.Commands.DeleteTodoItem;
using DnaBrasilApi.Application.TodoItems.Commands.UpdateTodoItem;
using DnaBrasilApi.Application.TodoItems.Commands.UpdateTodoItemDetail;
using DnaBrasilApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Todo Items
/// </summary>
public class TodoItems : EndpointGroupBase
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
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de itens de Tarefas Pendentes 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de itens de Tarefas Pendentes </param>
    /// <returns>Retorna o Id de novo Itens de Tarefas Pendentes </returns>
    public Task<int> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        return sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Itens de Tarefas Pendentes 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Itens de Tarefas Pendentes </param>
    /// <param name="command">Objeto de alteração de itens de Tarefas Pendentes </param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    /// <summary>
    /// Endpoint para alteração Detalhe de item de Tarefa
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração Detalhe de item de Tarefa</param>
    /// <param name="command">Objeto de alteração Detalhe de item de Tarefa</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    /// <summary>
    /// Endpoint para exclusão de itens de Tarefas Pendentes 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de itens de Tarefas Pendentes</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca Itens de Tarefas com Paginação
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="query">query</param>
    /// <returns> Retorna uma Lista de Tarefa </returns>
    public Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
    {
        return sender.Send(query);
    }
    #endregion
}
