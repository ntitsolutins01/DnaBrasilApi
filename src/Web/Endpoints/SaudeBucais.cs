using DnaBrasilApi.Application.Laudos.Commands.CreateSaudeBucal;
using DnaBrasilApi.Application.Laudos.Commands.UpdateSaudeBucal;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetSaudeBucalById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Saúde Bucais
/// </summary>
public class SaudeBucais : EndpointGroupBase
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
            .MapGet(GetSaudeBucalById, "{id}")
            .MapPost(CreateSaudeBucal)
            .MapPut(UpdateSaudeBucal, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Saúde Bucal
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Saúde Bucal</param>
    /// <returns>Retorna Id de nova Saúde Bucal</returns>
    public async Task<int> CreateSaudeBucal(ISender sender, CreateSaudeBucalCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Saúde Bucais
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Saúde Bucal</param>
    /// <param name="command">Objeto de alteração de Saúde Bucal</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateSaudeBucal(ISender sender, int id, UpdateSaudeBucalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca uma única Saúde Bucal
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Saúde Bucal a ser buscada</param>
    /// <returns>Retorna o objeto de Saúde Bucal </returns>
    public async Task<SaudeBucalDto> GetSaudeBucalById(ISender sender, int id)
    {
        return await sender.Send(new GetSaudeBucalByIdQuery() { Id = id });
    }
    #endregion
}
