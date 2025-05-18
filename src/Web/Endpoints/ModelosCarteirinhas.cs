using DnaBrasilApi.Application.ModelosCarteirinhas.Commands.CreateModeloCarteirinha;
using DnaBrasilApi.Application.ModelosCarteirinhas.Commands.DeleteModeloCarteirinha;
using DnaBrasilApi.Application.ModelosCarteirinhas.Commands.UpdateModeloCarteirinha;
using DnaBrasilApi.Application.ModelosCarteirinhas.Queries;
using DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaAll;
using DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaById;
using DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaByQuestionario;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de ModeloCarteirinha
/// </summary>
public class ModelosCarteirinhas : EndpointGroupBase
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
            .MapGet(GetModelosCarteirinhasAll)
            .MapPost(CreateModeloCarteirinha)
            .MapPut(UpdateModeloCarteirinha, "{id}")
            .MapDelete(DeleteModeloCarteirinha, "{id}")
            .MapGet(GetModeloCarteirinhaById, "{id}")
            .MapGet(GetModeloCarteirinhaByFomentoId, "Fomento/{fomentoId}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ModeloCarteirinha
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de ModeloCarteirinha</param>
    /// <returns>Retorna Id de nova ModeloCarteirinha</returns>
    public async Task<int> CreateModeloCarteirinha(ISender sender, CreateModeloCarteirinhaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ModeloCarteirinha
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de ModeloCarteirinha</param>
    /// <param name="command">Objeto de alteração de ModeloCarteirinha</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateModeloCarteirinha(ISender sender, int id, UpdateModeloCarteirinhaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ModeloCarteirinha
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de ModeloCarteirinha</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteModeloCarteirinha(ISender sender, int id)
    {
        return await sender.Send(new DeleteModeloCarteirinhaCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas os modelos de carteirinhas cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ModeloCarteirinha</returns>
    public async Task<List<ModeloCarteirinhaDto>> GetModelosCarteirinhasAll(ISender sender)
    {
        return await sender.Send(new GetModelosCarteirinhasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ModeloCarteirinha
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de ModeloCarteirinha a ser buscada</param>
    /// <returns>Retorna o objeto de ModeloCarteirinha </returns>
    public async Task<ModeloCarteirinhaDto> GetModeloCarteirinhaById(ISender sender, int id)
    {
        return await sender.Send(new GetModeloCarteirinhaByIdQuery() { Id = id });
    }

    /// <summary>
    ///  Endpoint que busca um único Modelo de Carteirinha por FomentoId 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="fomentoId">fomentoId</param>
    /// <returns>Retorna o Modelo de Carteirinha por FomentoId </returns>
    public async Task<ModeloCarteirinhaDto> GetModeloCarteirinhaByFomentoId(ISender sender, int fomentoId)
    {
        return await sender.Send(new GetModeloCarteirinhaByFomentoIdQuery() { FomentoId = fomentoId });
    }
    #endregion
}
