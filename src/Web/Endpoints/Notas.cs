using DnaBrasilApi.Application.Notas.Queries.GetNotaById;
using DnaBrasilApi.Application.Notas.Commands.CreateNota;
using DnaBrasilApi.Application.Notas.Commands.DeleteNota;
using DnaBrasilApi.Application.Notas.Commands.UpdateNota;
using DnaBrasilApi.Application.Notas.Queries;
using DnaBrasilApi.Application.Notas.Queries.GetNotasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Notas : EndpointGroupBase
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
            .MapGet(GetNotasAll)
            .MapPost(CreateNota)
            .MapPut(UpdateNota, "{id}")
            .MapDelete(DeleteNota, "{id}")
            .MapGet(GetNotaById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Nota
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Nota</param>
    /// <returns>Retorna Id da nova Nota</returns>
    public async Task<int> CreateNota(ISender sender, CreateNotaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Nota
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Nota</param>
    /// <param name="command">Objeto de alteração da Nota</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateNota(ISender sender, int id, UpdateNotaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Nota
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Nota</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteNota(ISender sender, int id)
    {
        return await sender.Send(new DeleteNotaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Notas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Notas</returns>
    public async Task<List<NotaDto>> GetNotasAll(ISender sender)
    {
        return await sender.Send(new GetNotasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Nota
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Nota a ser buscada</param>
    /// <returns>Retorna o objeto da Nota </returns>
    public async Task<NotaDto> GetNotaById(ISender sender, int id)
    {
        return await sender.Send(new GetNotaByIdQuery() { Id = id });
    }
    #endregion

}
