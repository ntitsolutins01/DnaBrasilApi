using DnaBrasilApi.Application.GrauParentescos.Commands.CreateGrauParentesco;
using DnaBrasilApi.Application.GrauParentescos.Commands.DeleteGrauParentesco;
using DnaBrasilApi.Application.GrauParentescos.Commands.UpdateGrauParentesco;
using DnaBrasilApi.Application.GrauParentescos.Queries;
using DnaBrasilApi.Application.GrauParentescos.Queries.GetGrauParentescoById;
using DnaBrasilApi.Application.GrauParentescos.Queries.GetGrauParentescosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class GrauParentescos : EndpointGroupBase
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
            .MapGet(GetGrauParentescosAll)
            .MapPost(CreateGrauParentesco)
            .MapPut(UpdateGrauParentesco, "{id}")
            .MapDelete(DeleteGrauParentesco, "{id}")
            .MapGet(GetGrauParentescoById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de GrauParentesco
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da GrauParentesco</param>
    /// <returns>Retorna Id da nova GrauParentesco</returns>
    public async Task<int> CreateGrauParentesco(ISender sender, CreateGrauParentescoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de GrauParentesco
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da GrauParentesco</param>
    /// <param name="command">Objeto de alteração da GrauParentesco</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateGrauParentesco(ISender sender, int id, UpdateGrauParentescoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de GrauParentesco
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da GrauParentesco</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteGrauParentesco(ISender sender, int id)
    {
        return await sender.Send(new DeleteGrauParentescoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as GrauParentescos cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de GrauParentescos</returns>
    public async Task<List<GrauParentescoDto>> GetGrauParentescosAll(ISender sender)
    {
        return await sender.Send(new GetGrauParentescosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única GrauParentesco
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da GrauParentesco a ser buscada</param>
    /// <returns>Retorna o objeto da GrauParentesco </returns>
    public async Task<GrauParentescoDto> GetGrauParentescoById(ISender sender, int id)
    {
        return await sender.Send(new GetGrauParentescoByIdQuery() { Id = id });
    }
    #endregion
}
