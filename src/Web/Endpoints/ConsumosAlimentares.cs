using DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetConsumoAlimentarById;
using DnaBrasilApi.Application.Laudos.Queries.GetConsumosAlimentaresAll;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de Consumos Alimentares
/// </summary>
public class ConsumosAlimentares : EndpointGroupBase
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
            .MapGet(GetConsumoAlimentarById, "{id}")
            .MapGet(GetConsumosAlimentaresAll)
            .MapPost(CreateConsumoAlimentar)
            .MapPut(UpdateConsumoAlimentar, "{id}");

    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Consumo Alimentar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Consumo Alimentar</param>
    /// <returns>Retorna Id do novo ConsumoAlimentar</returns>

    public async Task<int> CreateConsumoAlimentar(ISender sender, CreateConsumoAlimentarCommand command)
    {
        return await sender.Send(command);
    }
    /// <summary>
    /// Endpoint para alteração de Consumo Alimentar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da alteração de ConsumoAlimentar</param>
    /// <param name="command">Objeto de alteração de ConsumoAlimentar</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateConsumoAlimentar(ISender sender, int id, UpdateConsumoAlimentarCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Consumos Alimentares cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ConsumosAlimentares</returns>
    public async Task<ConsumoAlimentarDto> GetConsumoAlimentarById(ISender sender, int id)
    {
        return await sender.Send(new GetConsumoAlimentarByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca um único Consumo Alimentar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Consumo Alimentar a ser buscado</param>
    /// <returns>Retorna o objeto de Consumo Alimentar </returns>
    public async Task<List<ConsumoAlimentarDto>> GetConsumosAlimentaresAll(ISender sender)
    {
        return await sender.Send(new GetConsumosAlimentaresAllQuery());
    }
    #endregion
}
