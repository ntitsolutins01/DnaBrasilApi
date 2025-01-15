using DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControleMensalEstoqueById;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.CreateControleMensalEstoque;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.DeleteControleMensalEstoque;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.UpdateControleMensalEstoque;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Queries;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControlesMensaisEstoqueAll;
using DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControlesMensaisEstoqueByMaterialId;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesMensaisEstoque : EndpointGroupBase
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
            .MapGet(GetControlesMensaisEstoqueAll)
            .MapPost(CreateControleMensalEstoque)
            .MapPut(UpdateControleMensalEstoque, "{id}")
            .MapDelete(DeleteControleMensalEstoque, "{id}")
            .MapGet(GetControleMensalEstoqueById, "ControleMensalEstoque/{id}")
            .MapGet(GetControlesMensaisEstoqueByMaterialId, "Material/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ControleMensalEstoque
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da ControleMensalEstoque</param>
    /// <returns>Retorna Id da nova ControleMensalEstoque</returns>
    public async Task<int> CreateControleMensalEstoque(ISender sender, CreateControleMensalEstoqueCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ControleMensalEstoque
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ControleMensalEstoque</param>
    /// <param name="command">Objeto de alteração da ControleMensalEstoque</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControleMensalEstoque(ISender sender, int id, UpdateControleMensalEstoqueCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ControleMensalEstoque
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ControleMensalEstoque</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControleMensalEstoque(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleMensalEstoqueCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ControlesMensaisEstoque cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ControlesMensaisEstoque</returns>
    public async Task<List<ControleMensalEstoqueDto>> GetControlesMensaisEstoqueAll(ISender sender)
    {
        return await sender.Send(new GetControlesMensaisEstoqueAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ControleMensalEstoque
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ControleMensalEstoque a ser buscada</param>
    /// <returns>Retorna o objeto da ControleMensalEstoque </returns>
    public async Task<ControleMensalEstoqueDto> GetControleMensalEstoqueById(ISender sender, int id)
    {
        return await sender.Send(new GetControleMensalEstoqueByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de tipos de material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de ControlesMensaisEstoque</returns>
    public async Task<List<ControleMensalEstoqueDto>> GetControlesMensaisEstoqueByMaterialId(ISender sender, int id)
    {
        return await sender.Send(new GetControlesMensaisEstoqueByMaterialIdQuery() { MaterialId = id });
    }
    #endregion

}
