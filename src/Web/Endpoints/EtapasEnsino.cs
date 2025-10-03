using DnaBrasilApi.Application.EtapasEnsino.Commands.CreateEtapaEnsino;
using DnaBrasilApi.Application.EtapasEnsino.Commands.DeleteEtapaEnsino;
using DnaBrasilApi.Application.EtapasEnsino.Commands.UpdateEtapaEnsino;
using DnaBrasilApi.Application.EtapasEnsino.Queries;
using DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapaEnsinoById;
using DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapasEnsinoAll;
using DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapasEnsinoAtivas;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Etapas de Ensinos
/// </summary>
public class EtapasEnsino : EndpointGroupBase
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
            .MapGet(GetEtapasEnsinoAll)
            .MapGet(GetEtapasEnsinoAtivas, "Ativas")
            .MapPost(CreateEtapaEnsino)
            .MapPut(UpdateEtapaEnsino, "{id}")
            .MapDelete(DeleteEtapaEnsino, "{id}")
            .MapGet(GetEtapaEnsinoById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Etapas de Ensino
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Etapas de Ensino</param>
    /// <returns>Retorna Id de nova Etapas de Ensino</returns>
    public async Task<int> CreateEtapaEnsino(ISender sender, CreateEtapaEnsinoCommand command)
    {
        return await sender.Send(command);
    }

    ///// <summary>
    ///// Endpoint para alteração de Etapas de Ensino
    ///// </summary>
    ///// <param name="sender">Sender</param>
    ///// <param name="id">Id de alteração de Etapas de Ensino</param>
    ///// <param name="command">Objeto de alteração de Etapas de Ensino</param>
    ///// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEtapaEnsino(ISender sender, int id, UpdateEtapaEnsinoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    ///// <summary>
    ///// Endpoint para exclusão de Etapas de Ensino
    ///// </summary>
    ///// <param name="sender">Sender</param>
    ///// <param name="id">Id de Exclusão de Etapas de Ensino</param>
    ///// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteEtapaEnsino(ISender sender, int id)
    {
        return await sender.Send(new DeleteEtapaEnsinoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Etapas de Ensino cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Etapas de Ensino</returns>
    public async Task<List<EtapaEnsinoDto>> GetEtapasEnsinoAll(ISender sender)
    {
        return await sender.Send(new GetEtapasEnsinoAllQuery());
    }

    public async Task<List<EtapaEnsinoDto>> GetEtapasEnsinoAtivas(ISender sender)
    {
        return await sender.Send(new GetEtapasEnsinoAtivasQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Etapas de Ensino
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Etapas de Ensino a ser buscada</param>
    /// <returns>Retorna o objeto de Etapas de Ensino </returns>
    public async Task<EtapaEnsinoDto> GetEtapaEnsinoById(ISender sender, int id)
    {
        return await sender.Send(new GetEtapaEnsinoByIdQuery() { Id = id });
    }
    #endregion
}
