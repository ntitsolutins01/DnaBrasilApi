using DnaBrasilApi.Application.Categorias.Queries.GetCategoriaById;
using DnaBrasilApi.Application.Categorias.Commands.CreateCategoria;
using DnaBrasilApi.Application.Categorias.Commands.DeleteCategoria;
using DnaBrasilApi.Application.Categorias.Commands.UpdateCategoria;
using DnaBrasilApi.Application.Categorias.Queries;
using DnaBrasilApi.Application.Categorias.Queries.GetCategoriasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Categorias : EndpointGroupBase
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
            .MapPost(CreateCategoria)
            .MapPut(UpdateCategoria, "{id}")
            .MapDelete(DeleteCategoria, "{id}")
            .MapGet(GetCategoriasAll)
            .MapGet(GetCategoriaById, "Categoria/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Categoria
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Categoria</param>
    /// <returns>Retorna Id da nova Categoria</returns>
    public async Task<int> CreateCategoria(ISender sender, CreateCategoriaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Categoria
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Categoria</param>
    /// <param name="command">Objeto de alteração da Categoria</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateCategoria(ISender sender, int id, UpdateCategoriaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Categoria
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Categoria</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteCategoria(ISender sender, int id)
    {
        return await sender.Send(new DeleteCategoriaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Categorias cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Categorias</returns>
    public async Task<List<CategoriaDto>> GetCategoriasAll(ISender sender)
    {
        return await sender.Send(new GetCategoriasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Categoria
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Categoria a ser buscada</param>
    /// <returns>Retorna o objeto da Categoria </returns>
    public async Task<CategoriaDto> GetCategoriaById(ISender sender, int id)
    {
        return await sender.Send(new GetCategoriaByIdQuery() { Id = id });
    }
    #endregion

}
