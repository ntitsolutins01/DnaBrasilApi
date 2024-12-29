using DnaBrasilApi.Application.Fomentos.Commands.CreateFomento;
using DnaBrasilApi.Application.Fomentos.Commands.DeleteFomento;
using DnaBrasilApi.Application.Fomentos.Commands.UpdateFomento;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Application.Fomentos.Queries.GetFomentoById;
using DnaBrasilApi.Application.Fomentos.Queries.GetFomentoByLocalidadeId;
using DnaBrasilApi.Application.Fomentos.Queries.GetFomentosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Fomentos : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetFomentosAll)
            .MapPost(CreateFomento)
            .MapPut(UpdateFomento, "{id}")
            .MapDelete(DeleteFomento, "{id}")
            .MapGet(GetFomentoByLocalidadeId, "/Localidade/{id}")
            .MapGet(GetFomentoById, "/Fomento/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Fomento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Fomento</param>
    /// <returns>Retorna Id do novo Fomento</returns>
    public async Task<int> CreateFomento(ISender sender, CreateFomentoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Fomento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Fomento</param>
    /// <param name="command">Objeto de alteração de Fomento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateFomento(ISender sender, int id, UpdateFomentoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Fomento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Fomento</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteFomento(ISender sender, int id)
    {
        return await sender.Send(new DeleteFomentoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Fomentos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Fomentos</returns>
    public async Task<List<FomentoDto>> GetFomentosAll(ISender sender)
    {
        return await sender.Send(new GetFomentosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Fomento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Fomento a ser buscado</param>
    /// <returns>Retorna um objeto de Fomento </returns>
    public async Task<FomentoDto> GetFomentoById(ISender sender, int id)
    {
        return await sender.Send(new GetFomentoByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca Fomento por localidade id 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id que busca Fomento por localidade</param>
    /// <returns>retona a lista de Fomento</returns>
    public async Task<FomentoDto> GetFomentoByLocalidadeId(ISender sender, int id)
    {
        return await sender.Send(new GetFomentoByLocalidadeIdQuery() { Id = id });
    }
    #endregion
}













