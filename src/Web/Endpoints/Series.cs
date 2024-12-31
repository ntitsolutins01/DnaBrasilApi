using DnaBrasilApi.Application.Series.Queries.GetSerieById;
using DnaBrasilApi.Application.Series.Commands.CreateSerie;
using DnaBrasilApi.Application.Series.Commands.DeleteSerie;
using DnaBrasilApi.Application.Series.Commands.UpdateSerie;
using DnaBrasilApi.Application.Series.Queries;
using DnaBrasilApi.Application.Series.Queries.GetSeriesAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Séries
/// </summary>
public class Series : EndpointGroupBase
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
            .MapGet(GetSeriesAll)
            .MapPost(CreateSerie)
            .MapPut(UpdateSerie, "{id}")
            .MapDelete(DeleteSerie, "{id}")
            .MapGet(GetSerieById, "Serie/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Série
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Série</param>
    /// <returns>Retorna Id de nova Série</returns>
    public async Task<int> CreateSerie(ISender sender, CreateSerieCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Série
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Série</param>
    /// <param name="command">Objeto de alteração de Série</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateSerie(ISender sender, int id, UpdateSerieCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Série
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Exclusão de Série</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteSerie(ISender sender, int id)
    {
        return await sender.Send(new DeleteSerieCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Série cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Série</returns>
    public async Task<List<SerieDto>> GetSeriesAll(ISender sender)
    {
        return await sender.Send(new GetSeriesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Série
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Série a ser buscada</param>
    /// <returns>Retorna o objeto de Série </returns>
    public async Task<SerieDto> GetSerieById(ISender sender, int id)
    {
        return await sender.Send(new GetSerieByIdQuery() { Id = id });
    }
    #endregion
}
