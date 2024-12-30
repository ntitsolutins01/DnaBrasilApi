using DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoQualidadeVida;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetQualidadeDeVidasAll;
using DnaBrasilApi.Application.Laudos.Queries.GetQualidadeVidaById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Qualidade de Vida
/// </summary>
public class QualidadeDeVidas : EndpointGroupBase
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
            .MapPost(CreateQualidadeDeVida)
            .MapPut(UpdateQualidadeDeVida, "{id}")
            .MapGet(GetQualidadeDeVidasAll)
            .MapGet(GetQualidadeDeVidaById, "{id}");

    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Qualidade de Vida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Qualidade de Vida</param>
    /// <returns>Retorna Id de nova Qualidade de Vida</returns>
    public async Task<int> CreateQualidadeDeVida(ISender sender, CreateQualidadeDeVidaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Qualidade de Vida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Qualidade de Vida</param>
    /// <param name="command">Objeto de alteração de Qualidade de Vida</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateQualidadeDeVida(ISender sender, int id, UpdateEncaminhamentoQualidadeDeVidaCommand command)
    {
        if (id != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca uma única Qualidade de Vida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Qualidade de Vida a ser buscada</param>
    /// <returns>Retorna o objeto de Qualidade de Vida </returns>
    public async Task<QualidadeDeVidaDto> GetQualidadeDeVidaById(ISender sender, int id)
    {
        return await sender.Send(new GetQualidadeVidaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca todas as Qualidades de Vida cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Qualidade de Vida</returns>
    public async Task<List<QualidadeDeVidaDto>> GetQualidadeDeVidasAll(ISender sender)
    {
        return await sender.Send(new GetQualidadeDeVidasAllQuery());
    }
    #endregion
}
