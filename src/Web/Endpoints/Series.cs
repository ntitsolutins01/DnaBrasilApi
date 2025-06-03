using DnaBrasilApi.Application.Series.Commands.CreateSerie;
using DnaBrasilApi.Application.Series.Commands.DeleteSerie;
using DnaBrasilApi.Application.Series.Commands.UpdateSerie;
using DnaBrasilApi.Application.Series.Queries;
using DnaBrasilApi.Application.Series.Queries.GetSerieById;
using DnaBrasilApi.Application.Series.Queries.GetSeriesAll;
using DnaBrasilApi.Application.Series.Queries.GetSeriesByLocalidadeIdEtapaId;
using DnaBrasilApi.Application.Series.Queries.GetTurmasByLocalidadeId;
using DnaBrasilApi.Application.Series.Queries.GetTurmasByLocalidadeIdEtapaIdSerie;

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
            .MapGet(GetSerieById, "{id}")
            .MapGet(GetSeriesByLocalidadeIdEtapaId, "Localidade/{localidadeId}/Etapa/{etapaId}")
            .MapGet(GetTurmasByLocalidadeIdEtapaIdSerie, "Localidade/{localidadeId}/Etapa/{etapaId}/Serie/{serie}")
            .MapGet(GetTurmasByLocalidadeId, "Localidade/{localidadeId}");
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

    /// <summary>
    /// Endpoint que busca uma lista de séries por localidade e etapa
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="localidadeId">Id da localidade</param>
    /// <param name="etapaId">Id da etapa de ensino</param>
    /// <returns>Retorna a lista de Série</returns>
    public async Task<List<SerieDto>> GetSeriesByLocalidadeIdEtapaId(ISender sender, int localidadeId, int etapaId)
    {
        return await sender.Send(new GetSeriesByLocalidadeIdEtapaIdQuery() { LocalidadeId = localidadeId, EtapaId = etapaId });
    }

    /// <summary>
    /// Endpoint que busca uma lista de séries por localidade, etapa e série
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="localidadeId">Id da localidade</param>
    /// <param name="etapaId">Id da etapa de ensino</param>
    /// <param name="serie">Série selecionada</param>
    /// <returns>Retorna a lista de Série</returns>
    public async Task<List<SerieDto>> GetTurmasByLocalidadeIdEtapaIdSerie(ISender sender, int localidadeId, int etapaId, string serie)
    {
        return await sender.Send(new GetTurmasByLocalidadeIdEtapaIdSerieQuery() { LocalidadeId = localidadeId, EtapaId = etapaId, Serie = serie });
    }

    /// <summary>
    /// Endpoint que busca uma lista de séries por localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="localidadeId">Id da localidade</param>
    /// <returns>Retorna a lista de Série</returns>
    public async Task<List<SerieDto>> GetTurmasByLocalidadeId(ISender sender, int localidadeId)
    {
        return await sender.Send(new GetTurmasByLocalidadeIdQuery() { LocalidadeId = localidadeId });
    }
    #endregion
}
