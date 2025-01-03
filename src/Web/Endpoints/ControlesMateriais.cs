using DnaBrasilApi.Application.ControlesMateriais.Queries.GetControleMaterialById;
using DnaBrasilApi.Application.ControlesMateriais.Commands.CreateControleMaterial;
using DnaBrasilApi.Application.ControlesMateriais.Commands.DeleteControleMaterial;
using DnaBrasilApi.Application.ControlesMateriais.Commands.UpdateControleMaterial;
using DnaBrasilApi.Application.ControlesMateriais.Queries;
using DnaBrasilApi.Application.ControlesMateriais.Queries.GetControlesMateriaisAll;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de Controle de Materiais
/// </summary>
public class ControlesMateriais : EndpointGroupBase
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
            .MapGet(GetControlesMateriaisAll)
            .MapPost(CreateControleMaterial)
            .MapPut(UpdateControleMaterial, "{id}")
            .MapDelete(DeleteControleMaterial, "{id}")
            .MapGet(GetControleMaterialById, "ControleMaterial/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Controle de Material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Controle de Material</param>
    /// <returns>Retorna Id do novo Controle de Material</returns>
    public async Task<int> CreateControleMaterial(ISender sender, CreateControleMaterialCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ControleMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ControleMaterial</param>
    /// <param name="command">Objeto de alteração da ControleMaterial</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControleMaterial(ISender sender, int id, UpdateControleMaterialCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ControleMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ControleMaterial</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControleMaterial(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleMaterialCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ControlesMateriais cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ControlesMateriais</returns>
    public async Task<List<ControleMaterialDto>> GetControlesMateriaisAll(ISender sender)
    {
        return await sender.Send(new GetControlesMateriaisAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ControleMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ControleMaterial a ser buscada</param>
    /// <returns>Retorna o objeto da ControleMaterial </returns>
    public async Task<ControleMaterialDto> GetControleMaterialById(ISender sender, int id)
    {
        return await sender.Send(new GetControleMaterialByIdQuery() { Id = id });
    }
    #endregion
}
