using DnaBrasilApi.Application.Materiais.Queries.GetMaterialById;
using DnaBrasilApi.Application.Materiais.Commands.CreateMaterial;
using DnaBrasilApi.Application.Materiais.Commands.DeleteMaterial;
using DnaBrasilApi.Application.Materiais.Commands.UpdateMaterial;
using DnaBrasilApi.Application.Materiais.Queries;
using DnaBrasilApi.Application.Materiais.Queries.GetMateriaisAll;
using DnaBrasilApi.Application.Materiais.Queries.GetMateriaisByTipoMaterialId;

namespace DnaBrasilApi.Web.Endpoints;

public class Materiais : EndpointGroupBase
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
            .MapGet(GetMateriaisAll)
            .MapPost(CreateMaterial)
            .MapPut(UpdateMaterial, "{id}")
            .MapDelete(DeleteMaterial, "{id}")
            .MapGet(GetMaterialById, "Material/{id}")
            .MapGet(GetMateriaisByTipoMaterialId, "TipoMaterial/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Material</param>
    /// <returns>Retorna Id da nova Material</returns>
    public async Task<int> CreateMaterial(ISender sender, CreateMaterialCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Material</param>
    /// <param name="command">Objeto de alteração da Material</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateMaterial(ISender sender, int id, UpdateMaterialCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Material</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteMaterial(ISender sender, int id)
    {
        return await sender.Send(new DeleteMaterialCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Materiais cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Materiais</returns>
    public async Task<List<MaterialDto>> GetMateriaisAll(ISender sender)
    {
        return await sender.Send(new GetMateriaisAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Material a ser buscada</param>
    /// <returns>Retorna o objeto da Material </returns>
    public async Task<MaterialDto> GetMaterialById(ISender sender, int id)
    {
        return await sender.Send(new GetMaterialByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de tipos de material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de Materiais</returns>
    public async Task<List<MaterialDto>> GetMateriaisByTipoMaterialId(ISender sender, int id)
    {
        return await sender.Send(new GetMateriaisByTipoMaterialIdQuery() { TipoMaterialId = id });
    }
    #endregion

}
