using Azure.Core;
using DnaBrasilApi.Application.Perfis.Commands.CreatePerfil;
using DnaBrasilApi.Application.Perfis.Commands.DeletePerfil;
using DnaBrasilApi.Application.Perfis.Commands.UpdatePerfil;
using DnaBrasilApi.Application.Perfis.Queries;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfilByAspNetRoleId;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfilById;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfisAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Perfis
/// </summary>
public class Perfis : EndpointGroupBase
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
            .MapGet(GetPerfisAll)
            .MapGet(GetPerfilByAspNetRoleId, "AspNetRoleId/{aspNetRoleId}")
            .MapGet(GetPerfilById, "{id}")
            .MapPost(CreatePerfil)
            .MapPut(UpdatePerfil, "{id}")
            .MapDelete(DeletePerfil, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Perfis
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Perfis</param>
    /// <returns>Retorna Id de novo Perfis</returns>
    public async Task<int> CreatePerfil(ISender sender, CreatePerfilCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Perfis
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Perfis</param>
    /// <param name="command">Objeto de alteração de Perfis</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdatePerfil(ISender sender, int id, UpdatePerfilCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Perfis
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Perfis</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeletePerfil(ISender sender, int id)
    {
        return await sender.Send(new DeletePerfilCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Perfis cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Perfis</returns>
    public async Task<List<PerfilDto>> GetPerfisAll(ISender sender)
    {
        return await sender.Send(new GetPerfisAllQuery());
    }
    /// <summary>
    ///  Endpoint que busca Perfil por id de Funçao de Rede Asp
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="aspNetRoleId"> id de Funçao de rede Asp</param>
    /// <returns>retorna a lista de Perfis</returns>
    public async Task<PerfilDto> GetPerfilByAspNetRoleId(ISender sender, string aspNetRoleId)
    {
        return await sender.Send(new GetPerfilByAspNetRoleIdQuery
        {
            AspNetRoleId = aspNetRoleId
        });
    }

    /// <summary>
    /// Endpoint que busca um único Perfil
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Perfis a ser buscada</param>
    /// <returns>Retorna o objeto de Perfis </returns>
    public async Task<PerfilDto> GetPerfilById(ISender sender, int id)
    {
        return await sender.Send(new GetPerfilByIdQuery { Id = id });
    }
    #endregion
}



