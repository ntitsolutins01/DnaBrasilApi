using DnaBrasilApi.Application.MetricasImc.Commands.CreateMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Commands.DeleteMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Queries;
using DnaBrasilApi.Application.MetricasImc.Queries.GetMetricaImcById;
using DnaBrasilApi.Application.MetricasImc.Queries.GetMetricasImcAll;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de métricas Imc
/// </summary>
public class MetricasImc : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMetricasImcAll)
            .MapPost(CreateMetricaImc)
            .MapPut(UpdateMetricaImc, "{id}")
            .MapDelete(DeleteMetricaImc, "{id}")
            .MapGet(GetMetricaImcById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Métricas Imc
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Métricas Imc</param>
    /// <returns>Retorna Id de novas Métricas Imc</returns>
    public async Task<int> CreateMetricaImc(ISender sender, CreateMetricaImcCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Métriicas Imc
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Métricas Imc</param>
    /// <param name="command">Objeto de alteração de métricas Imc</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateMetricaImc(ISender sender, int id, UpdateMetricaImcCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de métricas Imc
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Métricas Imc</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteMetricaImc(ISender sender, int id)
    {
        return await sender.Send(new DeleteMetricaImcCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Métricas Imc cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Métricas Imc</returns
    public async Task<List<MetricaImcDto>> GetMetricasImcAll(ISender sender)
    {
        return await sender.Send(new GetMetricasImcAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Métricas Imc
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Métricas Imc a ser buscada</param>
    /// <returns>Retorna o objeto de Métricas Imc </returns>
    public async Task<MetricaImcDto> GetMetricaImcById(ISender sender, int id)
    {
        return await sender.Send(new GetMetricaImcByIdQuery() { Id = id });
    }
    #endregion
}
