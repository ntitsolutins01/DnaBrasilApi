using DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadeById;
using DnaBrasilApi.Application.Escolaridades.Queries;
using DnaBrasilApi.Application.Escolaridades.Commands.CreateEscolaridade;
using DnaBrasilApi.Application.Escolaridades.Commands.DeleteEscolaridade;
using DnaBrasilApi.Application.Escolaridades.Commands.UpdateEscolaridade;
using DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Escolaridades : EndpointGroupBase
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
            .MapGet(GetEscolaridadesAll)
            .MapPost(CreateEscolaridade)
            .MapPut(UpdateEscolaridade, "{id}")
            .MapDelete(DeleteEscolaridade, "{id}")
            .MapGet(GetEscolaridadeById, "{id}");
    }



    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Escolaridade 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Escolaridade</param>
    /// <returns>Retorna Id de nova Escolaridade</returns>
    public async Task<int> CreateEscolaridade(ISender sender, CreateEscolaridadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Escolaridade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Escolaridade</param>
    /// <param name="command">Objeto de alteração de Escolaridade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEscolaridade(ISender sender, int id, UpdateEscolaridadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    /// <summary>
    /// Endpoint para exclusão de Escolaridade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Escolaridade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteEscolaridade(ISender sender, int id)
    {
        return await sender.Send(new DeleteEscolaridadeCommand(id));
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca Escolaridades cadastradas
    /// </summary>
    /// <param name="sender">sender</param>
    /// <returns>retorna a uma Escolaridade</returns>
    public async Task<List<EscolaridadeDto>> GetEscolaridadesAll(ISender sender)
    {
        return await sender.Send(new GerEscolaridadesAllQuery());
    }
    /// <summary>
    /// Endpoint que busca Escolaridade por id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id"> id de Escolaridade</param>
    /// <returns>retorna a um id de Escolaridade</returns>
    public async Task<EscolaridadeDto> GetEscolaridadeById(ISender sender, int id)
    {
        return await sender.Send(new GetEscolaridadeByIdQuery() { Id = id });
    }
    #endregion
}



