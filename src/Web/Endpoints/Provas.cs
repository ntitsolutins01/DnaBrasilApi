using DnaBrasilApi.Application.Provas.Queries.GetProvaById;
using DnaBrasilApi.Application.Provas.Commands.CreateProva;
using DnaBrasilApi.Application.Provas.Commands.DeleteProva;
using DnaBrasilApi.Application.Provas.Commands.UpdateProva;
using DnaBrasilApi.Application.Provas.Queries;
using DnaBrasilApi.Application.Provas.Queries.GetProvasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Provas : EndpointGroupBase
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
            .MapGet(GetProvasAll)
            .MapPost(CreateProva)
            .MapPut(UpdateProva, "{id}")
            .MapDelete(DeleteProva, "{id}")
            .MapGet(GetProvaById, "Prova/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Prova
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Prova</param>
    /// <returns>Retorna Id da nova Prova</returns>
    public async Task<int> CreateProva(ISender sender, CreateProvaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Prova
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Prova</param>
    /// <param name="command">Objeto de alteração da Prova</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateProva(ISender sender, int id, UpdateProvaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Prova
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Prova</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteProva(ISender sender, int id)
    {
        return await sender.Send(new DeleteProvaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Provas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Provas</returns>
    public async Task<List<ProvaDto>> GetProvasAll(ISender sender)
    {
        return await sender.Send(new GetProvasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Prova
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Prova a ser buscada</param>
    /// <returns>Retorna o objeto da Prova </returns>
    public async Task<ProvaDto> GetProvaById(ISender sender, int id)
    {
        return await sender.Send(new GetProvaByIdQuery() { Id = id });
    }
    #endregion

}
