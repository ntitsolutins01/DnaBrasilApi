using DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateVocacional;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetVocacionalById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Vocacionais
/// </summary>
public class Vocacionais : EndpointGroupBase
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
            .MapGet(GetVocacionalById, "{id}")
            .MapPost(CreateVocacional)
            .MapPut(UpdateVocacional, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Vocacional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Vocacionail</param>
    /// <returns>Retorna Id de um novo Vocacional</returns>
    public async Task<int> CreateVocacional(ISender sender, CreateVocacionalCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Vocacional 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Vocacional </param>
    /// <param name="command">Objeto de alteração da Vocacional </param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateVocacional(ISender sender, int id, UpdateVocacionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca um único Vocacional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Vocacional a ser buscado</param>
    /// <returns>Retorna o objeto de Vocacional</returns>
    public async Task<VocacionalDto> GetVocacionalById(ISender sender, int id)
    {
        return await sender.Send(new GetVocacionalByIdQuery() { Id = id });
    }
    #endregion
}
