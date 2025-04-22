using DnaBrasilApi.Application.ArquivosInventarios.Commands.CreateArquivosInventario;
using DnaBrasilApi.Application.ArquivosInventarios.Commands.DeleteArquivosInventario;
using DnaBrasilApi.Application.ArquivosInventarios.Commands.UpdateArquivosInventario;
using DnaBrasilApi.Application.ArquivosInventarios.Queries;
using DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventarioById;
using DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventariosAll;
using DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventariosByInventarioId;

namespace DnaBrasilApi.Web.Endpoints;

public class ArquivosInventarios : EndpointGroupBase
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
            .MapGet(GetArquivosInventariosAll)
            .MapPost(CreateArquivosInventario)
            .MapPut(UpdateArquivosInventario, "{id}")
            .MapDelete(DeleteArquivosInventario, "{id}")
            .MapGet(GetArquivosInventarioById, "{id}")
            .MapGet(GetArquivosInventariosByInventarioId, "Inventario/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ArquivosInventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da ArquivosInventario</param>
    /// <returns>Retorna Id da nova ArquivosInventario</returns>
    public async Task<int> CreateArquivosInventario(ISender sender, CreateArquivosInventarioCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ArquivosInventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ArquivosInventario</param>
    /// <param name="command">Objeto de alteração da ArquivosInventario</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateArquivosInventario(ISender sender, int id, UpdateArquivosInventarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ArquivosInventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ArquivosInventario</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteArquivosInventario(ISender sender, int id)
    {
        return await sender.Send(new DeleteArquivosInventarioCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ArquivosInventarios cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ArquivosInventarios</returns>
    public async Task<List<ArquivosInventarioDto>> GetArquivosInventariosAll(ISender sender)
    {
        return await sender.Send(new GetArquivosInventariosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ArquivosInventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ArquivosInventario a ser buscada</param>
    /// <returns>Retorna o objeto da ArquivosInventario </returns>
    public async Task<ArquivosInventarioDto> GetArquivosInventarioById(ISender sender, int id)
    {
        return await sender.Send(new GetArquivosInventarioByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de inventario pelo  material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do Inventario</param>
    /// <returns>Retorna uma lista de ArquivosInventarios</returns>
    public async Task<List<ArquivosInventarioDto>> GetArquivosInventariosByInventarioId(ISender sender, int id)
    {
        return await sender.Send(new GetArquivosInventariosByInventarioIdQuery() { InventarioId = id });
    }

    #endregion

}
