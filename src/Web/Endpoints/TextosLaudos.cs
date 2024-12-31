using DnaBrasilApi.Application.TextosLaudos.Commands.CreateTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Commands.DeleteTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Commands.UpdateTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Queries;
using DnaBrasilApi.Application.TextosLaudos.Queries.GetTextoLaudoById;
using DnaBrasilApi.Application.TextosLaudos.Queries.GetTextosLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Textos Laudos
/// </summary>
public class TextosLaudos : EndpointGroupBase
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
            .MapGet(GetTextosLaudosAll)
            .MapPost(CreateTextoLaudo)
            .MapPut(UpdateTextoLaudo, "{id}")
            .MapDelete(DeleteTextoLaudo, "{id}")
            .MapGet(GetTextoLaudoById, "TextoLaudo/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Texto e Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Texto e Laudo</param>
    /// <returns>Retorna Id de novo Texto e Laudo</returns>
    public async Task<int> CreateTextoLaudo(ISender sender, CreateTextoLaudoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Texto e Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Texto e Laudo</param>
    /// <param name="command">Objeto de alteração de Texto e Laudo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTextoLaudo(ISender sender, int id, UpdateTextoLaudoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Texto e Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Exclusão de Texto e Laudo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTextoLaudo(ISender sender, int id)
    {
        return await sender.Send(new DeleteTextoLaudoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Texto e Laudos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Texto e Laudos</returns>
    public async Task<List<TextoLaudoDto>> GetTextosLaudosAll(ISender sender)
    {
        return await sender.Send(new GetTextosLaudosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Texto e Laudo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Texto e Laudo a ser buscado</param>
    /// <returns>Retorna o objeto de Texto e Laudo </returns>
    public async Task<TextoLaudoDto> GetTextoLaudoById(ISender sender, int id)
    {
        return await sender.Send(new GetTextoLaudoByIdQuery() { Id = id });
    }
    #endregion
}
