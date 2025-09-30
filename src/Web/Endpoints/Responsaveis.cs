using DnaBrasilApi.Application.Responsaveis.Commands.CreateResponsavel;
using DnaBrasilApi.Application.Responsaveis.Commands.DeleteResponsavel;
using DnaBrasilApi.Application.Responsaveis.Commands.UpdateResponsavel;
using DnaBrasilApi.Application.Responsaveis.Queries;
using DnaBrasilApi.Application.Responsaveis.Queries.GetResponsaveisAll;
using DnaBrasilApi.Application.Responsaveis.Queries.GetResponsavelById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
///  Api de Responsaveis
/// </summary>
public class Responsaveis : EndpointGroupBase
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
            .MapGet(GetResponsaveisAll)
            .MapPost(CreateResponsavel)
            .MapPut(UpdateResponsavel, "{id}")
            .MapDelete(DeleteResponsavel, "{id}")
            .MapGet(GetResponsavelById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Responsavel
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Responsavel</param>
    /// <returns>Retorna Id de novo Responsavel</returns>
    public async Task<int> CreateResponsavel(ISender sender, CreateResponsavelCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Responsavel
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Responsavel</param>
    /// <param name="command">Objeto de alteração de Responsavel</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateResponsavel(ISender sender, int id, UpdateResponsavelCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Responsavel
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de Responsavel</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteResponsavel(ISender sender, int id)
    {
        return await sender.Send(new DeleteResponsavelCommand(id));
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca todos os Tipos de Cursos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Responsavel</returns>
    public async Task<List<ResponsavelDto>> GetResponsaveisAll(ISender sender)
    {
        return await sender.Send(new GetResponsaveisAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Responsavel
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Responsavel a ser buscado</param>
    /// <returns>Retorna o objeto da Aula </returns>
    public async Task<ResponsavelDto> GetResponsavelById(ISender sender, int id)
    {
        return await sender.Send(new GetResponsavelByIdQuery() { Id = id });
    }
    #endregion
}
