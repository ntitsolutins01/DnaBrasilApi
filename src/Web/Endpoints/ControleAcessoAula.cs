using DnaBrasilApi.Application.ControlesAcessosAulas.Queries.GetControleAcessoAulaById;
using DnaBrasilApi.Application.ControlesAcessosAulas.Commands.CreateControleAcessoAula;
using DnaBrasilApi.Application.ControlesAcessosAulas.Commands.DeleteControleAcessoAula;
using DnaBrasilApi.Application.ControlesAcessosAulas.Commands.UpdateControleAcessoAula;
using DnaBrasilApi.Application.ControlesAcessosAulas.Queries;
using DnaBrasilApi.Application.ControlesAcessosAulas.Queries.GetControlesAcessosAulasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesAcessosAulas : EndpointGroupBase
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
            .MapGet(GetControlesAcessosAulasAll)
            .MapPost(CreateControleAcessoAula)
            .MapPut(UpdateControleAcessoAula, "{id}")
            .MapDelete(DeleteControleAcessoAula, "{id}")
            .MapGet(GetControleAcessoAulaById, "ControleAcessoAula/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ControleAcessoAula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da ControleAcessoAula</param>
    /// <returns>Retorna Id da nova ControleAcessoAula</returns>
    public async Task<int> CreateControleAcessoAula(ISender sender, CreateControleAcessoAulaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ControleAcessoAula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ControleAcessoAula</param>
    /// <param name="command">Objeto de alteração da ControleAcessoAula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControleAcessoAula(ISender sender, int id, UpdateControleAcessoAulaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ControleAcessoAula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ControleAcessoAula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControleAcessoAula(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleAcessoAulaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ControlesAcessosAulas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ControlesAcessosAulas</returns>
    public async Task<List<ControleAcessoAulaDto>> GetControlesAcessosAulasAll(ISender sender)
    {
        return await sender.Send(new GetControlesAcessosAulasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ControleAcessoAula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ControleAcessoAula a ser buscada</param>
    /// <returns>Retorna o objeto da ControleAcessoAula </returns>
    public async Task<ControleAcessoAulaDto> GetControleAcessoAulaById(ISender sender, int id)
    {
        return await sender.Send(new GetControleAcessoAulaByIdQuery() { Id = id });
    }
    #endregion

}
