using DnaBrasilApi.Application.Parceiros.Commands.CreateParceiro;
using DnaBrasilApi.Application.Parceiros.Commands.DeleteParceiro;
using DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;
using DnaBrasilApi.Application.Parceiros.Queries;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroAll;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroByAspNetUserId;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Parceiros
/// </summary>
public class Parceiros : EndpointGroupBase
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
            .MapGet(GetParceirosAll)
            .MapPost(CreateParceiro)
            .MapPut(UpdateParceiro, "{id}")
            .MapDelete(DeleteParceiro, "{id}")
            .MapGet(GetParceiroById, "Parceiro/{id}")
            .MapGet(GetParceiroByAspNetUserId, "Parceiro/AspNetUser/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Parceiro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Parceiro</param>
    /// <returns>Retorna Id de novo Parceiro</returns>
    public async Task<int> CreateParceiro(ISender sender, CreateParceiroCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Parceiro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Parceiro</param>
    /// <param name="command">Objeto de alteração de Parceiro</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateParceiro(ISender sender, int id, UpdateParceiroCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Parceiro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de Parceiro</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteParceiro(ISender sender, int id)
    {
        return await sender.Send(new DeleteParceiroCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Parceiros cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Parceiros</returns>
    public async Task<List<ParceiroDto>> GetParceirosAll(ISender sender)
    {
        return await sender.Send(new GetParceirosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Parceiro
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Parceiro a ser buscado</param>
    /// <returns>Retorna o objeto de Parceiro </returns>
    public async Task<ParceiroDto> GetParceiroById(ISender sender, int id)
    {
        return await sender.Send(new GetParceiroByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca Parceiro por id de Usuário 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="aspNetUserId">aspNetUserId</param>
    /// <returns></returns>
    public async Task<ParceiroDto> GetParceiroByAspNetUserId(ISender sender, string aspNetUserId)
    {
        return await sender.Send(new GetParceiroByAspNetUserIdQuery() { AspNetUserId = aspNetUserId });
    }
    #endregion
}
