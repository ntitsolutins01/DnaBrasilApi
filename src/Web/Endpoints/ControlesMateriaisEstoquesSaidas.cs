using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControleMaterialEstoqueSaidaById;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.CreateControleMaterialEstoqueSaida;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.DeleteControleMaterialEstoqueSaida;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.UpdateControleMaterialEstoqueSaida;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasAll;
using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasByMaterialId;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesMateriaisEstoquesSaidas : EndpointGroupBase
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
            .MapGet(GetControlesMateriaisEstoquesSaidasAll)
            .MapPost(CreateControleMaterialEstoqueSaida)
            .MapPut(UpdateControleMaterialEstoqueSaida, "{id}")
            .MapDelete(DeleteControleMaterialEstoqueSaida, "{id}")
            .MapGet(GetControleMaterialEstoqueSaidaById, "ControleMaterialEstoqueSaida/{id}")
            .MapGet(GetControlesMateriaisEstoquesSaidasByMaterialId, "Material/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ControleMaterialEstoqueSaida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da ControleMaterialEstoqueSaida</param>
    /// <returns>Retorna Id da nova ControleMaterialEstoqueSaida</returns>
    public async Task<int> CreateControleMaterialEstoqueSaida(ISender sender, CreateControleMaterialEstoqueSaidaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ControleMaterialEstoqueSaida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ControleMaterialEstoqueSaida</param>
    /// <param name="command">Objeto de alteração da ControleMaterialEstoqueSaida</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControleMaterialEstoqueSaida(ISender sender, int id, UpdateControleMaterialEstoqueSaidaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ControleMaterialEstoqueSaida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ControleMaterialEstoqueSaida</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControleMaterialEstoqueSaida(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleMaterialEstoqueSaidaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ControlesMateriaisEstoquesSaidas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ControlesMateriaisEstoquesSaidas</returns>
    public async Task<List<ControleMaterialEstoqueSaidaDto>> GetControlesMateriaisEstoquesSaidasAll(ISender sender)
    {
        return await sender.Send(new GetControlesMateriaisEstoquesSaidasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ControleMaterialEstoqueSaida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ControleMaterialEstoqueSaida a ser buscada</param>
    /// <returns>Retorna o objeto da ControleMaterialEstoqueSaida </returns>
    public async Task<ControleMaterialEstoqueSaidaDto> GetControleMaterialEstoqueSaidaById(ISender sender, int id)
    {
        return await sender.Send(new GetControleMaterialEstoqueSaidaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de tipos de material
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de ControlesMateriaisEstoquesSaidas</returns>
    public async Task<List<ControleMaterialEstoqueSaidaDto>> GetControlesMateriaisEstoquesSaidasByMaterialId(ISender sender, int id)
    {
        return await sender.Send(new GetControlesMateriaisEstoquesSaidasByMaterialIdQuery() { MaterialId = id });
    }
    #endregion

}
