using DnaBrasilApi.Application.Aulas.Queries.GetAulaById;
using DnaBrasilApi.Application.Aulas.Commands.CreateAula;
using DnaBrasilApi.Application.Aulas.Commands.DeleteAula;
using DnaBrasilApi.Application.Aulas.Commands.UpdateAula;
using DnaBrasilApi.Application.Aulas.Queries;
using DnaBrasilApi.Application.Aulas.Queries.GetAulasAll;
using DnaBrasilApi.Application.Aulas.Queries.GetAulasAllByModuloEadId;

namespace DnaBrasilApi.Web.Endpoints;

public class Aulas : EndpointGroupBase
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
            .MapGet(GetAulasAll)
            .MapPost(CreateAula)
            .MapPut(UpdateAula, "{id}")
            .MapDelete(DeleteAula, "{id}")
            .MapGet(GetAulaById, "Aula/{id}")
            .MapGet(GetAulasAllByModuloEadId, "ModuloEad/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Aula</param>
    /// <returns>Retorna Id da nova Aula</returns>
    public async Task<int> CreateAula(ISender sender, CreateAulaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Aula</param>
    /// <param name="command">Objeto de alteração da Aula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAula(ISender sender, int id, UpdateAulaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Aula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAula(ISender sender, int id)
    {
        return await sender.Send(new DeleteAulaCommand(id));
    }
    #endregion 

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Aulas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Aulas</returns>
    public async Task<List<AulaDto>> GetAulasAll(ISender sender)
    {
        return await sender.Send(new GetAulasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Aula a ser buscada</param>
    /// <returns>Retorna o objeto da Aula </returns>
    public async Task<AulaDto> GetAulaById(ISender sender, int id)
    {
        return await sender.Send(new GetAulaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de aulas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de Aulas</returns>
    public async Task<List<AulaDto>> GetAulasAllByModuloEadId(ISender sender, int id)
    {
        return await sender.Send(new GetAulasAllByModuloEadIdQuery() { ModuloEadId = id });
    }
    #endregion
}
