using DnaBrasilApi.Application.Estruturas.Queries.GetEstruturaById;
using DnaBrasilApi.Application.Estruturas.Commands.CreateEstrutura;
using DnaBrasilApi.Application.Estruturas.Commands.DeleteEstrutura;
using DnaBrasilApi.Application.Estruturas.Commands.UpdateEstrutura;
using DnaBrasilApi.Application.Estruturas.Queries;
using DnaBrasilApi.Application.Estruturas.Queries.GetEstruturasAll;
using DnaBrasilApi.Application.Estruturas.Queries.GetEstruturasByLocalidade;

namespace DnaBrasilApi.Web.Endpoints;

public class Estruturas : EndpointGroupBase
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
            .MapPost(CreateEstrutura)
            .MapPut(UpdateEstrutura, "{id}")
            .MapDelete(DeleteEstrutura, "{id}")
            .MapGet(GetEstruturasAll)
            .MapGet(GetEstruturaById, "Estrutura/{id}")
            .MapGet(GetEstruturasByLocalidade, "Localidade/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Estrutura
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Estrutura</param>
    /// <returns>Retorna Id da nova Estrutura</returns>
    public async Task<int> CreateEstrutura(ISender sender, CreateEstruturaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Estrutura
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Estrutura</param>
    /// <param name="command">Objeto de alteração da Estrutura</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEstrutura(ISender sender, int id, UpdateEstruturaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Estrutura
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Estrutura</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteEstrutura(ISender sender, int id)
    {
        return await sender.Send(new DeleteEstruturaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Estruturas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Estruturas</returns>
    public async Task<List<EstruturaDto>> GetEstruturasAll(ISender sender)
    {
        return await sender.Send(new GetEstruturasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Estrutura
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Estrutura a ser buscada</param>
    /// <returns>Retorna o objeto da Estrutura </returns>
    public async Task<EstruturaDto> GetEstruturaById(ISender sender, int id)
    {
        return await sender.Send(new GetEstruturaByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca todas as estruturas por localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da localidade</param>
    /// <returns>Retorna a lista de Estruturas</returns>
    public async Task<List<EstruturaDto>> GetEstruturasByLocalidade(ISender sender, int id)
    {
        return await sender.Send(new GetEstruturasByLocalidadeQuery { LocalidadeId = id });
    }
    #endregion

}
