using DnaBrasilApi.Application.TipoLaudos.Queries.GetTipoLaudoById;
using DnaBrasilApi.Application.TipoLaudos.Queries;
using DnaBrasilApi.Application.TipoLaudos.Commands.CreateTipoLaudos;
using DnaBrasilApi.Application.TipoLaudos.Commands.DeleteTipoLaudos;
using DnaBrasilApi.Application.TipoLaudos.Commands.UpdateTipoLaudos;
using DnaBrasilApi.Application.TipoLaudos.Queries.GetTipoLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Tipos de Laudos
/// </summary>
public class TiposLaudos : EndpointGroupBase
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
            .MapGet(GetTiposLaudosAll)
            .MapPost(CreateTipoLaudo)
            .MapPut(UpdateTipoLaudo, "{id}")
            .MapDelete(DeleteTipoLaudo, "{id}")
            .MapGet(GetTipoLaudoById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Tipo de Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Tipo de Laudo</param>
    /// <returns>Retorna Id de novo Tipo de Laudo</returns>
    public async Task<int> CreateTipoLaudo(ISender sender, CreateTipoLaudosCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Tipo de Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Tipo de Laudo</param>
    /// <param name="command">Objeto de alteração da Tipo de Laudo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTipoLaudo(ISender sender, int id, UpdateTipoLaudoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Tipo de Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão da Tipo de Laudo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTipoLaudo(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoLaudoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Tipo de Laudo cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Tipo de Laudo</returns>
    public async Task<List<TipoLaudoDto>> GetTiposLaudosAll(ISender sender)
    {
        return await sender.Send(new GetTipoLaudosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Tipo de Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Tipo de Laudo a ser buscado</param>
    /// <returns>Retorna o objeto de Tipo de Laudo </returns>
    public async Task<TipoLaudoDto> GetTipoLaudoById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoLaudoByIdQuery() { Id = id });
    }
    #endregion
}
