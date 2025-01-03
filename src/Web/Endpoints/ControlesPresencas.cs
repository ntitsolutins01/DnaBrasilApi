using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasAll;
using DnaBrasilApi.Application.ControlesPresencas.Commands.CreateControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Commands.DeleteControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Commands.UpdateControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Queries;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlePresencaById;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByAlunoId;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByFilter;
using Microsoft.AspNetCore.Mvc;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByEventoId;
using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesPresencas : EndpointGroupBase
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
            .MapGet(GetControlesPresencasAll)
            .MapPost(CreateControlePresenca)
            .MapPut(UpdateControlePresenca, "{id}")
            .MapDelete(DeleteControlePresenca, "{id}")
            .MapGet(GetControlePresencaById, "{id}")
            .MapGet(GetControlesPresencasByAlunoId, "Aluno/{alunoId}")
            .MapGet(GetControlesPresencasByEventoId, "Evento/{eventoId}")
            .MapPost(GetControlesPresencasByFilter, "Filter");
    }



    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Controle Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Controle Presenca</param>
    /// <returns>Retorna Id de novo Controle Presenca</returns>
    public async Task<int> CreateControlePresenca(ISender sender, CreateControlePresencaCommand command)
    {
        return await sender.Send(command);
    }
    /// <summary>
    /// Endpoint para alteração de Controle Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Controle Presença</param>
    /// <param name="command">Objeto de alteração de Controle Presença</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControlePresenca(ISender sender, int id, UpdateControlePresencaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    /// <summary>
    /// Endpoint para exclusão de Controle Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Controle Presença</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControlePresenca(ISender sender, int id)
    {
        return await sender.Send(new DeleteControlePresencaCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca o controle de presença por filtro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="search">Filtro de pesquisa</param>
    /// <returns>Retorna o objeto de controle de presença</returns>
    public async Task<ControlesPresencasFilterDto> GetControlesPresencasByFilter(ISender sender, [FromBody] ControlesPresencasFilterDto search)
    {
        var result = await sender.Send(new GetControlesPresencasByFilterQuery() { SearchFilter = search });

        search.ControlesPresencas = result;

        return search;
    }
    /// <summary>
    /// Endpoint que busca todos os Controle de Presenças cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Controle de Presenças</returns>
    public async Task<PaginatedList<ControlePresencaDto>> GetControlesPresencasAll(ISender sender, [AsParameters] GetControlesPresencasAllQuery query)
    {
        return await sender.Send(query);
    }
    /// <summary>
    /// Endpoint que Busca o Controle de Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do Aluno</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<ControlePresencaDto> GetControlePresencaById(ISender sender, int id)
    {
        return await sender.Send(new GetControlePresencaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que Busca o controle de presença por id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="eventoId">Evento id</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<List<ControlePresencaDto>> GetControlesPresencasByEventoId(ISender sender, int eventoId)
    {
        return await sender.Send(new GetControlesPresencasByEventoIdQuery() { EventoId = eventoId });
    }
    /// <summary>
    /// Endpoint que Busca controle de Presença por Evento id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="alunoId">Id do Aluno</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<List<ControlePresencaDto>> GetControlesPresencasByAlunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetControlesPresencasByAlunoIdQuery() { AlunoId = alunoId });
    }
    #endregion
}
