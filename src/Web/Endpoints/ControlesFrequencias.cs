using DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasAll;
using DnaBrasilApi.Application.ControlesFrequencias.Commands.CreateControleFrequencia;
using DnaBrasilApi.Application.ControlesFrequencias.Commands.DeleteControleFrequencia;
using DnaBrasilApi.Application.ControlesFrequencias.Commands.UpdateControleFrequencia;
using DnaBrasilApi.Application.ControlesFrequencias.Queries;
using DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControleFrequenciaById;
using DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByAlunoId;
using DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByFilter;
using Microsoft.AspNetCore.Mvc;
using DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByDisciplinaId;
using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesFrequencias : EndpointGroupBase
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
            .MapGet(GetControlesFrequenciasAll)
            .MapPost(CreateControleFrequencia)
            .MapPut(UpdateControleFrequencia, "{id}")
            .MapDelete(DeleteControleFrequencia, "{id}")
            .MapGet(GetControleFrequenciaById, "{id}")
            .MapGet(GetControlesFrequenciasByAlunoId, "Aluno/{alunoId}")
            .MapGet(GetControlesFrequenciasByDisciplinaId, "Disciplina/{disciplinaId}")
            .MapPost(GetControlesFrequenciasByFilter, "Filter");
    }



    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Controle Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Controle Frequencia</param>
    /// <returns>Retorna Id de novo Controle Frequencia</returns>
    public async Task<int> CreateControleFrequencia(ISender sender, CreateControleFrequenciaCommand command)
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
    public async Task<bool> UpdateControleFrequencia(ISender sender, int id, UpdateControleFrequenciaCommand command)
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
    public async Task<bool> DeleteControleFrequencia(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleFrequenciaCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca o controle de presença por filtro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="search">Filtro de pesquisa</param>
    /// <returns>Retorna o objeto de controle de presença</returns>
    public async Task<ControlesFrequenciasFilterDto> GetControlesFrequenciasByFilter(ISender sender, [FromBody] ControlesFrequenciasFilterDto search)
    {
        var result = await sender.Send(new GetControlesFrequenciasByFilterQuery() { SearchFilter = search });

        search.ControlesFrequencias = result;

        return search;
    }
    /// <summary>
    /// Endpoint que busca todos os Controle de Presenças cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Controle de Presenças</returns>
    public async Task<PaginatedList<ControleFrequenciaDto>> GetControlesFrequenciasAll(ISender sender, [AsParameters] GetControlesFrequenciasAllQuery query)
    {
        return await sender.Send(query);
    }
    /// <summary>
    /// Endpoint que Busca o Controle de Presença
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do Aluno</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<ControleFrequenciaDto> GetControleFrequenciaById(ISender sender, int id)
    {
        return await sender.Send(new GetControleFrequenciaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que Busca o controle de presença por id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="disciplinaId">Disciplina id</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<List<ControleFrequenciaDto>> GetControlesFrequenciasByDisciplinaId(ISender sender, int disciplinaId)
    {
        return await sender.Send(new GetControlesFrequenciasByDisciplinaIdQuery() { DisciplinaId = disciplinaId });
    }
    /// <summary>
    /// Endpoint que Busca controle de Presença por Disciplina id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="alunoId">Id do Aluno</param>
    /// <returns>Retorna a lista de Controle de Presença</returns>
    public async Task<List<ControleFrequenciaAlunoDto>> GetControlesFrequenciasByAlunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetControlesFrequenciasByAlunoIdQuery() { AlunoId = alunoId });
    }
    #endregion
}
