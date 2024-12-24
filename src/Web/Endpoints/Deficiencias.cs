using DnaBrasilApi.Application.Aulas.Commands.DeleteAula;
using DnaBrasilApi.Application.Aulas.Queries.GetAulasAllByModuloEadId;
using DnaBrasilApi.Application.Aulas.Queries;
using DnaBrasilApi.Application.Deficiencias.Commands.CreateDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Commands.DeleteDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Commands.UpdateDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Queries;
using DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciaById;
using DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Deficiencias : EndpointGroupBase
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
            .MapGet(GetDeficienciasAll)
            .MapGet(GetDeficienciaById, "Deficiencia/{id}")
            .MapPost(CreateDeficiencia)
            .MapPut(UpdateDeficiencia, "{id}")
            .MapDelete(DeleteDeficiencia, "{id}");
    }
    #endregion

    #region Main Methods


    /// <summary>
    /// Endpoint para inclusão de Deficiencia
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Deficiencia</param>
    /// <returns>Retorna Id da nova Deficiencia</returns>
    public async Task<int> CreateDeficiencia(ISender sender, CreateDeficienciaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração da Deficiencia
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Deficiencia</param>
    /// <param name="command">Objeto de alteração da Deficiencia</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateDeficiencia(ISender sender, int id, UpdateDeficienciaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão da Deficiencia
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Deficiencia</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteDeficiencia(ISender sender, int id)
    {
        return await sender.Send(new DeleteDeficienciaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Deficiencia cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Deficiencia</returns>
    public async Task<List<DeficienciaDto>> GetDeficienciasAll(ISender sender)
    {
        return await sender.Send(new GetDeficienciasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Deficiencia
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Deficiencia a ser buscada</param>
    /// <returns>Retorna o objeto da Deficiencia </returns>
    public async Task<DeficienciaDto> GetDeficienciaById(ISender sender, int id)
    {
        return await sender.Send(new GetDeficienciaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de Deficiencia pelo modulo ead id
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista da Deficiencia</returns>
    public async Task<List<AulaDto>> GetAulasAllByModuloEadId(ISender sender, int id)
    {
        return await sender.Send(new GetAulasAllByModuloEadIdQuery() { ModuloEadId = id });
    }




    #endregion

}
