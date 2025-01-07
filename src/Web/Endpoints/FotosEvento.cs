using DnaBrasilApi.Application.Eventos.Commands.DeleteEvento;
using DnaBrasilApi.Application.FotosEvento.Commands.CreateFotoEvento;
using DnaBrasilApi.Application.FotosEvento.Commands.DeleteFotoEvento;
using DnaBrasilApi.Application.FotosEvento.Queries;
using DnaBrasilApi.Application.FotosEvento.Queries.GetFotoEventoById;
using DnaBrasilApi.Application.FotosEvento.Queries.GetFotosAllByEventoId;

namespace DnaBrasilApi.Web.Endpoints;

public class FotosEvento : EndpointGroupBase
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
            .MapGet(GetFotosAllByEventoId, "{eventoId}")
            .MapPost(CreateFotoEvento)
            .MapDelete(DeleteFotoEvento, "{id}")
            .MapGet(GetFotoEventoById, "Foto/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de fotos do evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Evento</param>
    /// <returns>Retorna Id da nova Evento</returns>
    public async Task<int> CreateFotoEvento(ISender sender, List<CreateFotoEventoDto> list)
    {
        var listFotoIds = new List<int>();

        foreach (var item in list)
        {
            var command = new CreateFotoEventoCommand()
            {
                EventoId = item.EventoId, NomeArquivo = item.NomeArquivo, Url = item.Url
            };

            var idFoto = await sender.Send(command);

            listFotoIds.Add(idFoto);
        }

        return listFotoIds.Count;
    }

    /// <summary>
    /// Endpoint para exclusão de foto do evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da foto do evento </param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteFotoEvento(ISender sender, int id)
    {
        return await sender.Send(new DeleteFotoEventoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Fotos do Evento cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="eventoId">Id do Evento</param>
    /// <returns>Retorna a lista de Fotos do Evento</returns>
    public async Task<List<FotoEventoDto>> GetFotosAllByEventoId(ISender sender, int eventoId)
    {
        return await sender.Send(new GetFotosAllByEventoIdQuery() { EventoId = eventoId });
    }

    /// <summary>
    /// Endpoint que busca uma única foto Evento
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da foto do Evento a ser buscada</param>
    /// <returns>Retorna o objeto da foto do Evento </returns>
    public async Task<FotoEventoDto> GetFotoEventoById(ISender sender, int id)
    {
        return await sender.Send(new GetFotoEventoByIdQuery() { Id = id });
    }
    #endregion

}
