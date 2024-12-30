using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioById;
using DnaBrasilApi.Application.Questionarios.Commands.CreateQuestionario;
using DnaBrasilApi.Application.Questionarios.Commands.DeleteQuestionario;
using DnaBrasilApi.Application.Questionarios.Commands.UpdateQuestionario;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioAll;
using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioByTipoLaudo;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Questionario
/// </summary>
public class Questionarios : EndpointGroupBase
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
            .MapGet(GetQuestionariosAll)
            .MapPost(CreateQuestionario)
            .MapPut(UpdateQuestionario, "{id}")
            .MapDelete(DeleteQuestionario, "{id}")
            .MapGet(GetQuestionarioByTipoLaudo, "TipoLaudo/{id}")
            .MapGet(GetQuestionarioById, "Questionario/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Questionário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Questionário</param>
    /// <returns>Retorna Id de novo Questionário</returns>
    public async Task<int> CreateQuestionario(ISender sender, CreateQuestionarioCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Questionário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Questionário</param>
    /// <param name="command">Objeto de alteração de Questionário</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateQuestionario(ISender sender, int id, UpdateQuestionarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Questionário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Questionário</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteQuestionario(ISender sender, int id)
    {
        return await sender.Send(new DeleteQuestionarioCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca Quetionário por Tipo de Laudo
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id de Questionário por Laudo</param>
    /// <returns>Retorna a uma Lista de Questionário</returns>
    public async Task<List<QuestionarioDto>> GetQuestionarioByTipoLaudo(ISender sender, int id)
    {
        return await sender.Send(new GetQuestionarioByTipoLaudoQuery() { TipoLaudoId = id });
    }

    /// <summary>
    /// Endpoint que busca todos os Questionários cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a Lista de Questionário</returns>
    public async Task<List<QuestionarioDto>> GetQuestionariosAll(ISender sender)
    {
        return await sender.Send(new GetQuestionariosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Questionário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Questionário a ser buscado</param>
    /// <returns>Retorna o objeto do Quetionário</returns>
    public async Task<QuestionarioDto> GetQuestionarioById(ISender sender, int id)
    {
        return await sender.Send(new GetQuestionarioByIdQuery() { Id = id });
    }
    #endregion
}
