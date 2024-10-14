using DnaBrasilApi.Application.ModulosEad.Queries.GetModuloEadById;
using DnaBrasilApi.Application.ModulosEad.Commands.CreateModuloEad;
using DnaBrasilApi.Application.ModulosEad.Commands.DeleteModuloEad;
using DnaBrasilApi.Application.ModulosEad.Commands.UpdateModuloEad;
using DnaBrasilApi.Application.ModulosEad.Queries;
using DnaBrasilApi.Application.ModulosEad.Queries.GetModulosEadAll;
using DnaBrasilApi.Application.ModulosEad.Queries.GetModulosEadAllByCursoId;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Web.Endpoints;

public class ModulosEad : EndpointGroupBase
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
            .MapGet(GetModulosEadAll)
            .MapPost(CreateModuloEad)
            .MapPut(UpdateModuloEad, "{id}")
            .MapDelete(DeleteModuloEad, "{id}")
            .MapGet(GetModuloEadById, "ModuloEad/{id}")
            .MapGet(GetModulosEadAllByCursoId, pattern:"Curso/{cursoId}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de ModuloEad
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da ModuloEad</param>
    /// <returns>Retorna Id da nova ModuloEad</returns>
    public async Task<int> CreateModuloEad(ISender sender, CreateModuloEadCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de ModuloEad
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da ModuloEad</param>
    /// <param name="command">Objeto de alteração da ModuloEad</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateModuloEad(ISender sender, int id, UpdateModuloEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de ModuloEad
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da ModuloEad</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteModuloEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteModuloEadCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ModulosEad cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ModulosEad</returns>
    public async Task<List<ModuloEadDto>> GetModulosEadAll(ISender sender)
    {
        return await sender.Send(new GetModulosEadAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única ModuloEad
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da ModuloEad a ser buscada</param>
    /// <returns>Retorna o objeto da ModuloEad </returns>
    public async Task<ModuloEadDto> GetModuloEadById(ISender sender, int id)
    {
        return await sender.Send(new GetModuloEadByIdQuery() { Id = id });
    }

    
    public async Task<List<ModuloEadDto>> GetModulosEadAllByCursoId(ISender sender, int cursoId)
    {
        return await sender.Send(new GetModulosEadAllByCursoIdQuery() { CursoId = cursoId });
    }
    #endregion

}
