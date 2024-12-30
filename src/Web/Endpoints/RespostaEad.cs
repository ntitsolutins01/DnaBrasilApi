using DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Commands.DeleteRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Queries;
using DnaBrasilApi.Application.RespostasEad.Queries.GetRespostaEadById;
using DnaBrasilApi.Application.RespostasEad.Queries.GetRespostasEadAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Resposta Ead
/// </summary>
public class RespostasEad : EndpointGroupBase
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
            .MapGet(GetRespostasEadAll)
            .MapPost(CreateRespostaEad)
            .MapPut(UpdateRespostaEad, "{id}")
            .MapDelete(DeleteRespostaEad, "{id}")
            .MapGet(GetRespostaEadById, "RespostaEad/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Resposta Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Resposta Ead</param>
    /// <returns>Retorna Id de nova Resposta Ead</returns>
    public async Task<int> CreateRespostaEad(ISender sender, CreateRespostaEadCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Resposta Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Resposta Ead</param>
    /// <param name="command">Objeto de alteração de Resposta Ead</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateRespostaEad(ISender sender, int id, UpdateRespostaEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Resposta Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Resposta Ead</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteRespostaEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteRespostaEadCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Resposta Ead cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Resposta Ead</returns>
    public async Task<List<RespostaEadDto>> GetRespostasEadAll(ISender sender)
    {
        return await sender.Send(new GetRespostasEadAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Resposta Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Resposta Ead a ser buscada</param>
    /// <returns>Retorna o objeto de Resposta Ead </returns>
    public async Task<RespostaEadDto> GetRespostaEadById(ISender sender, int id)
    {
        return await sender.Send(new GetRespostaEadByIdQuery() { Id = id });
    }
    #endregion
}
