using DnaBrasilApi.Application.Inventarios.Commands.CreateInventario;
using DnaBrasilApi.Application.Inventarios.Commands.DeleteInventario;
using DnaBrasilApi.Application.Inventarios.Commands.UpdateInventario;
using DnaBrasilApi.Application.Inventarios.Queries;
using DnaBrasilApi.Application.Inventarios.Queries.GetInventarioById;
using DnaBrasilApi.Application.Inventarios.Queries.GetInventariosAll;
using DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByFilter;
using DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByLocalidadeId;
using DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByMaterialId;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Inventarios : EndpointGroupBase
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
            .MapGet(GetInventariosAll)
            .MapPost(CreateInventario)
            .MapPut(UpdateInventario, "{id}")
            .MapDelete(DeleteInventario, "{id}")
            .MapGet(GetInventarioById, "{id}")
            .MapGet(GetInventariosByMaterialId, "Material/{id}")
            .MapGet(GetInventariosByLocalidadeId, "Localidade/{id}")
            .MapPost(GetInventariosByFilter, "Filter"); ;
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Inventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Inventario</param>
    /// <returns>Retorna Id da nova Inventario</returns>
    public async Task<int> CreateInventario(ISender sender, CreateInventarioCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Inventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Inventario</param>
    /// <param name="command">Objeto de alteração da Inventario</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateInventario(ISender sender, int id, UpdateInventarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Inventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Inventario</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteInventario(ISender sender, int id)
    {
        return await sender.Send(new DeleteInventarioCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Inventarios cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Inventarios</returns>
    public async Task<List<InventarioDto>> GetInventariosAll(ISender sender)
    {
        return await sender.Send(new GetInventariosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca Inventarios por Filtro 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="search">filtro para pesquisas de Inventarios</param>
    /// <returns>retorna a lista de Inventarios</returns>
    public async Task<InventariosFilterDto> GetInventariosByFilter(ISender sender, [FromBody] InventariosFilterDto search)
    {
        var result = await sender.Send(new GetInventariosByFilterQuery() { SearchFilter = search });

        return new InventariosFilterDto { Inventarios = result };
    }

    /// <summary>
    /// Endpoint que busca uma única Inventario
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Inventario a ser buscada</param>
    /// <returns>Retorna o objeto da Inventario </returns>
    public async Task<InventarioDto> GetInventarioById(ISender sender, int id)
    {
        return await sender.Send(new GetInventarioByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de inventario pelo  material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do Material</param>
    /// <returns>Retorna uma lista de Inventarios</returns>
    public async Task<List<InventarioDto>> GetInventariosByMaterialId(ISender sender, int id)
    {
        return await sender.Send(new GetInventariosByMaterialIdQuery() { MaterialId = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de inventario pelo  localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do Localidade</param>
    /// <returns>Retorna uma lista de Inventarios</returns>
    public async Task<List<InventarioDto>> GetInventariosByLocalidadeId(ISender sender, int id)
    {
        return await sender.Send(new GetInventariosByLocalidadeIdQuery() { LocalidadeId = id });
    }

    #endregion

}
