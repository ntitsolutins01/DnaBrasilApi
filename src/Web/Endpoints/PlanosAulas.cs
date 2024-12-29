using DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanoAulaById;
using DnaBrasilApi.Application.PlanosAulas.Queries;
using DnaBrasilApi.Application.PlanosAulas.Commands.CreatePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Commands.DeletePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Commands.UpdatePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanosAulasAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Planos de Aulas
/// </summary>
public class PlanosAulas : EndpointGroupBase
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
            .MapGet(GetPlanosAulasAll)
            .MapPost(CreatePlanoAula)
            .MapPut(UpdatePlanoAula, "{id}")
            .MapDelete(DeletePlanoAula, "{id}")
            .MapGet(GetPlanoAulaById, "PlanoAula/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Plano de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Plano Aula</param>
    /// <returns>Retorna Id novo de Plano de Aula</returns>
    public async Task<int> CreatePlanoAula(ISender sender, CreatePlanoAulaCommand command)
    {
        return await sender.Send(command);
    }
    /// <summary>
    /// Endpoint para alteração de Plano de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Plano Aula</param>
    /// <param name="command">Objeto de alteração de Plano Aula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdatePlanoAula(ISender sender, int id, UpdatePlanoAulaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Plano de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Plano Aula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeletePlanoAula(ISender sender, int id)
    {
        return await sender.Send(new DeletePlanoAulaCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Planos de Aulas cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Planos Aulas</returns>
    public async Task<List<PlanoAulaDto>> GetPlanosAulasAll(ISender sender)
    {
        return await sender.Send(new GetPlanosAulasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Plano de Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Plano de Aula a ser buscado</param>
    /// <returns>Retorna o objeto de Plano de Aula </returns>
    public async Task<PlanoAulaDto> GetPlanoAulaById(ISender sender, int id)
    {
        return await sender.Send(new GetPlanoAulaByIdQuery() { Id = id });
    }
    #endregion
}
