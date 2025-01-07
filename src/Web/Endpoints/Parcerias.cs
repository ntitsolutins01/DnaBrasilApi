using DnaBrasilApi.Application.TiposParcerias.Commands.CreateTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Commands.DeleteTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Commands.UpdateTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Queries;
using DnaBrasilApi.Application.TiposParcerias.Queries.GetTipoParceriaById;
using DnaBrasilApi.Application.TiposParcerias.Queries.GetTiposParceriasAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Parcerias
/// </summary>
public class TipoParcerias : EndpointGroupBase
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
            .MapGet(GetTiposParceriasAll)
            .MapPost(CreateTipoParceria)
            .MapPut(UpdateTipoParceria, "{id}")
            .MapDelete(DeleteTipoParceria, "{id}")
            .MapGet(GetTipoParceriaById, "TipoParceria/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Parcerias
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Parcerias</param>
    /// <returns>Retorna Id de nova Parceria</returns>
    public async Task<int> CreateTipoParceria(ISender sender, CreateTipoParceriaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Parceria
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Parcerias</param>
    /// <param name="command">Objeto de alteração de Partcerias</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTipoParceria(ISender sender, int id, UpdateTipoParceriaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Parcerias
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Parcerias</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTipoParceria(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoParceriaCommand(id));
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca todas as Parceriass cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Parceriass</returns>
    public async Task<List<TipoParceriaDto>> GetTiposParceriasAll(ISender sender)
    {
        return await sender.Send(new GetTiposParceriasQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Parcerias
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Parcerias a ser buscada</param>
    /// <returns>Retorna o objeto de Parcerias </returns>
    public async Task<TipoParceriaDto> GetTipoParceriaById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoParceriaByIdQuery() { Id = id });
    }
    #endregion
}
