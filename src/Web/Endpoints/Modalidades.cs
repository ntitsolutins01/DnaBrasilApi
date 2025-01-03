using DnaBrasilApi.Application.Modalidades.Commands.CreateModalidade;
using DnaBrasilApi.Application.Modalidades.Commands.DeleteModalidade;
using DnaBrasilApi.Application.Modalidades.Commands.UpdateModalidade;
using DnaBrasilApi.Application.Modalidades.Queries;
using DnaBrasilApi.Application.Modalidades.Queries.GetModalidadeById;
using DnaBrasilApi.Application.Modalidades.Queries.GetAmbientesAll;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de Modalidades
/// </summary>
public class Modalidades : EndpointGroupBase
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
            .MapGet(GetModalidadesAll)
            .MapPost(CreateModalidade)
            .MapPut(UpdateModalidade, "{id}")
            .MapDelete(DeleteModalidade, "{id}")
            .MapGet(GetModalidadeById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Modalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Modalidade</param>
    /// <returns>Retorna Id da nova Modalidade</returns>
    public async Task<int> CreateModalidade(ISender sender, CreateModalidadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Modalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Modalidade</param>
    /// <param name="command">Objeto de alteração da Modalidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateModalidade(ISender sender, int id, UpdateModalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Modalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Modalidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteModalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteModalidadeCommand(id));
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca todas as Modalidades cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Modalidades</returns>
    public async Task<List<ModalidadeDto>> GetModalidadesAll(ISender sender)
    {
        return await sender.Send(new GetModalidadesQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Modalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Modalidade a ser buscada</param>
    /// <returns>Retorna o objeto da Modalidade </returns>
    public async Task<ModalidadeDto> GetModalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetModalidadeByIdQuery() { Id = id });
    }
    #endregion
}
