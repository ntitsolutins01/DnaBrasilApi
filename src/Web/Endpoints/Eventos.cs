using DnaBrasilApi.Application.Eventos.Queries.GetEventoById;
using DnaBrasilApi.Application.Eventos.Commands.CreateEvento;
using DnaBrasilApi.Application.Eventos.Commands.DeleteEvento;
using DnaBrasilApi.Application.Eventos.Commands.UpdateEvento;
using DnaBrasilApi.Application.Eventos.Queries;
using DnaBrasilApi.Application.Eventos.Queries.GetEventosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Eventos : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetEventosAll)
            .MapPost(CreateEvento)
            .MapPut(UpdateEvento, "{id}")
            .MapDelete(DeleteEvento, "{id}")
            .MapGet(GetEventoById, "Evento/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Evento</param>
    /// <returns>Retorna Id da nova Evento</returns>
    public async Task<int> CreateEvento(ISender sender, CreateEventoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Evento</param>
    /// <param name="command">Objeto de alteração da Evento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEvento(ISender sender, int id, UpdateEventoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Evento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteEvento(ISender sender, int id)
    {
        return await sender.Send(new DeleteEventoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Eventos cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Eventos</returns>
    public async Task<List<EventoDto>> GetEventosAll(ISender sender)
    {
        return await sender.Send(new GetEventosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Evento a ser buscada</param>
    /// <returns>Retorna o objeto da Evento </returns>
    public async Task<EventoDto> GetEventoById(ISender sender, int id)
    {
        return await sender.Send(new GetEventoByIdQuery() { Id = id });
    }
    #endregion

}
