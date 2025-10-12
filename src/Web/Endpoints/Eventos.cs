using DnaBrasilApi.Application.Eventos.Commands.CreateEvento;
using DnaBrasilApi.Application.Eventos.Commands.DeleteEvento;
using DnaBrasilApi.Application.Eventos.Commands.UpdateEvento;
using DnaBrasilApi.Application.Eventos.Queries;
using DnaBrasilApi.Application.Eventos.Queries.GetEventoById;
using DnaBrasilApi.Application.Eventos.Queries.GetEventosAll;
using DnaBrasilApi.Application.Eventos.Queries.GetEventosByMesAno;
using DnaBrasilApi.Application.Eventos.Queries.GetEventosByFilter;
using Microsoft.AspNetCore.Mvc;

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
            .MapGet(GetEventoById, "{id}")
            .MapGet(GetEventosByMesAno, "Mes/{mes}/Ano/{ano}")
            .MapPost(GetEventosByFilter, "Filter");
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

    /// <summary>
    /// Endpoint que busca os eventos do mes informado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="mesAno">Mes Ano</param>
    /// <returns>Retorna uma lista de eventos do mês ano informado </returns>
    public async Task<List<EventoDto>> GetEventosByMesAno(ISender sender, int mes, int ano)
    {
        return await sender.Send(new GetEventosByMesAnoQuery() { Mes = mes, Ano = ano });
    }

    /// <summary>
    /// Endpoint que busca Eventos por Filtro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="search">Filtro para pesquisa de Eventos</param>
    /// <returns>Retorna a lista de Eventos por Filtro</returns>
    public async Task<EventosFilterDto> GetEventosByFilter(ISender sender, [FromBody] EventosFilterDto search)
    {
        var result = await sender.Send(new GetEventosByFilterQuery() { SearchFilter = search });

        search.Eventos = result;

        return search;
    }
    #endregion
}
