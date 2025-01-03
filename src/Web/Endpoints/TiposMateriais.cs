using DnaBrasilApi.Application.TiposMateriais.Queries.GetTipoMaterialById;
using DnaBrasilApi.Application.TiposMateriais.Commands.CreateTipoMaterial;
using DnaBrasilApi.Application.TiposMateriais.Commands.DeleteTipoMaterial;
using DnaBrasilApi.Application.TiposMateriais.Commands.UpdateTipoMaterial;
using DnaBrasilApi.Application.TiposMateriais.Queries;
using DnaBrasilApi.Application.TiposMateriais.Queries.GetTiposMateriaisAll;
using DnaBrasilApi.Application.TiposMateriais.Queries.GetTiposMateriaisByGrupoMaterialId;

namespace DnaBrasilApi.Web.Endpoints;

public class TiposMateriais : EndpointGroupBase
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
            .MapGet(GetTiposMateriaisAll)
            .MapPost(CreateTipoMaterial)
            .MapPut(UpdateTipoMaterial, "{id}")
            .MapDelete(DeleteTipoMaterial, "{id}")
            .MapGet(GetTipoMaterialById, "TipoMaterial/{id}")
            .MapGet(GetTiposMateriaisByGrupoMaterialId, "GrupoMaterial/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de TipoMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da TipoMaterial</param>
    /// <returns>Retorna Id da nova TipoMaterial</returns>
    public async Task<int> CreateTipoMaterial(ISender sender, CreateTipoMaterialCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de TipoMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da TipoMaterial</param>
    /// <param name="command">Objeto de alteração da TipoMaterial</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTipoMaterial(ISender sender, int id, UpdateTipoMaterialCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de TipoMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da TipoMaterial</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTipoMaterial(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoMaterialCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as TiposMateriais cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de TiposMateriais</returns>
    public async Task<List<TipoMaterialDto>> GetTiposMateriaisAll(ISender sender)
    {
        return await sender.Send(new GetTiposMateriaisAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única TipoMaterial
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da TipoMaterial a ser buscada</param>
    /// <returns>Retorna o objeto da TipoMaterial </returns>
    public async Task<TipoMaterialDto> GetTipoMaterialById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoMaterialByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de tipos de material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de TiposMateriais</returns>
    public async Task<List<TipoMaterialDto>> GetTiposMateriaisByGrupoMaterialId(ISender sender, int id)
    {
        return await sender.Send(new GetTiposMateriaisByGrupoMaterialIdQuery() { GrupoMaterialId = id });
    }
    #endregion

}
