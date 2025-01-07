using DnaBrasilApi.Application.Laudos.Commands.CreateSaude;
using DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetSaudeById;


namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Saúde
/// </summary>
public class Saudes : EndpointGroupBase
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
            .MapPost(CreateSaude)
            .MapPut(UpdateSaude, "{id}")
            .MapGet(GetSaudeById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Saúde
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Saúde</param>
    /// <returns>Retorna Id de nova Saúde</returns>
    public async Task<int> CreateSaude(ISender sender, CreateSaudeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Saúde
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Saúde</param>
    /// <param name="command">Objeto de alteração de Saúde</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateSaude(ISender sender, int id, UpdateSaudeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca uma única Saúde
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Saúde a ser buscada</param>
    /// <returns>Retorna o objeto de Saúde </returns>
    public async Task<SaudeDto> GetSaudeById(ISender sender, int id)
    {
        return await sender.Send(new GetSaudeByIdQuery() { Id = id });
    }
    #endregion
}
