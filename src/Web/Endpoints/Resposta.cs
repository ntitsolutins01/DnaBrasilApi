using DnaBrasilApi.Application.Respostas.Queries.GetRespostaById;
using DnaBrasilApi.Application.Respostas.Commands.CreateResposta;
using DnaBrasilApi.Application.Respostas.Commands.DeleteResposta;
using DnaBrasilApi.Application.Respostas.Commands.UpdateResposta;
using DnaBrasilApi.Application.Respostas.Queries;
using DnaBrasilApi.Application.Respostas.Queries.GetRespostaAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Resposta
/// </summary>
public class Respostas : EndpointGroupBase
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
            .MapGet(GetRespostasAll)
            .MapPost(CreateResposta)
            .MapPut(UpdateResposta, "{id}")
            .MapDelete(DeleteResposta, "{id}")
            .MapGet(GetRespostaById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Resposta
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Resposta</param>
    /// <returns>Retorna Id de nova Resposta</returns>
    public async Task<int> CreateResposta(ISender sender, CreateRespostaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Resposta
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Resposta</param>
    /// <param name="command">Objeto de alteração de Resposta</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateResposta(ISender sender, int id, UpdateRespostaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Resposta
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Resposta</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteResposta(ISender sender, int id)
    {
        return await sender.Send(new DeleteRespostaCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Resposta cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Resposta</returns>
    public async Task<List<RespostaDto>> GetRespostasAll(ISender sender)
    {
        return await sender.Send(new GetRespostasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Resposta
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Resposta a ser buscada</param>
    /// <returns>Retorna o objeto de Resposta </returns>
    public async Task<RespostaDto> GetRespostaById(ISender sender, int id)
    {
        return await sender.Send(new GetRespostaByIdQuery() { Id = id });
    }
    #endregion
}
