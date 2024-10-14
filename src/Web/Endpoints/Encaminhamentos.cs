using DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentoById;
using DnaBrasilApi.Application.Encaminhamentos.Commands.CreateEncaminhamento;
using DnaBrasilApi.Application.Encaminhamentos.Commands.DeleteEncaminhamento;
using DnaBrasilApi.Application.Encaminhamentos.Commands.UpdateEncaminhamento;
using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentosAll;
using DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentosByTipoLaudoId;

namespace DnaBrasilApi.Web.Endpoints;

public class Encaminhamentos : EndpointGroupBase
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
            .MapGet(GetEncaminhamentosAll)
            .MapPost(CreateEncaminhamento)
            .MapPut(UpdateEncaminhamento, "{id}")
            .MapDelete(DeleteEncaminhamento, "{id}")
            .MapGet(GetEncaminhamentoById, "Encaminhamento/{id}")
            .MapGet(GetEncaminhamentosByTipoLaudoId, "Encaminhamento/TipoLaudo/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Encaminhamento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Encaminhamento</param>
    /// <returns>Retorna Id da nova Encaminhamento</returns>
    public async Task<int> CreateEncaminhamento(ISender sender, CreateEncaminhamentoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Encaminhamento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Encaminhamento</param>
    /// <param name="command">Objeto de alteração da Encaminhamento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamento(ISender sender, int id, UpdateEncaminhamentoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Encaminhamento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Encaminhamento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteEncaminhamento(ISender sender, int id)
    {
        return await sender.Send(new DeleteEncaminhamentoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Encaminhamentos cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Encaminhamentos</returns>
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentosAll(ISender sender)
    {
        return await sender.Send(new GetEncaminhamentosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Encaminhamento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Encaminhamento a ser buscada</param>
    /// <returns>Retorna o objeto da Encaminhamento </returns>
    public async Task<EncaminhamentoDto> GetEncaminhamentoById(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentoByIdQuery() { Id = id });
    }
    /// <summary>
    /// Endpoint que busca todos os encaminhamentos por tipo laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do tipo laudo</param>
    /// <returns>Retorna a lista de encaminhamentos</returns>
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentosByTipoLaudoId(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentosByTipoLaudoIdQuery() { Id = id });
    }
    #endregion

}
