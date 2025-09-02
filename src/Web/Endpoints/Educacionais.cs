using DnaBrasilApi.Application.Laudos.Commands.CreateEducacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEducacional;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetEducacionaisAll;
using DnaBrasilApi.Application.Laudos.Queries.GetEducacionalById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Educacionais
/// </summary>
public class Educacionais : EndpointGroupBase
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
            .MapGet(GetEducacionalById, "{id}")
            .MapPost(CreateEducacional)
            .MapPut(UpdateEducacional, "{id}")
            .MapGet(GetEducacionaisAll);
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Educacional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Vocacionail</param>
    /// <returns>Retorna Id de um novo Educacional</returns>
    public async Task<int> CreateEducacional(ISender sender, CreateEducacionalCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Educacional 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Educacional </param>
    /// <param name="command">Objeto de alteração da Educacional </param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEducacional(ISender sender, int id, UpdateEducacionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca um único Educacional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Educacional a ser buscado</param>
    /// <returns>Retorna o objeto de Educacional</returns>
    public async Task<EducacionalDto> GetEducacionalById(ISender sender, int id)
    {
        return await sender.Send(new GetEducacionalByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca todos os Educacionais cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Educacionais</returns>
    public async Task<List<EducacionalDto>> GetEducacionaisAll(ISender sender)
    {
        return await sender.Send(new GetEducacionaisAllQuery());
    }

    #endregion
}
