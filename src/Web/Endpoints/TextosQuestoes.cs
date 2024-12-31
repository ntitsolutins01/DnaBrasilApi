using DnaBrasilApi.Application.TextosQuestoes.Commands.CreateTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Commands.DeleteTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Commands.UpdateTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Queries;
using DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextoQuestaoById;
using DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextosQuestoesAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Texto Questões
/// </summary>
public class TextosQuestoes : EndpointGroupBase
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
            .MapGet(GetTextosQuestoesAll)
            .MapPost(CreateTextoQuestao)
            .MapPut(UpdateTextoQuestao, "{id}")
            .MapDelete(DeleteTextoQuestao, "{id}")
            .MapGet(GetTextoQuestaoById, "TextoQuestao/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Texto Questão
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Texto Questão</param>
    /// <returns>Retorna Id de novo Texto Questão</returns>
    public async Task<int> CreateTextoQuestao(ISender sender, CreateTextoQuestaoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Texto Questão
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Texto Questão</param>
    /// <param name="command">Objeto de alteração de Texto Questão</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTextoQuestao(ISender sender, int id, UpdateTextoQuestaoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Texto Questão
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Exclusão de Texto Questão</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTextoQuestao(ISender sender, int id)
    {
        return await sender.Send(new DeleteTextoQuestaoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas os Texto Questão cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Texto Questão</returns>
    public async Task<List<TextoQuestaoDto>> GetTextosQuestoesAll(ISender sender)
    {
        return await sender.Send(new GetTextosQuestoesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Texto Questão
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Texto Questão a ser buscado</param>
    /// <returns>Retorna o objeto de Texto Questão </returns>
    public async Task<TextoQuestaoDto> GetTextoQuestaoById(ISender sender, int id)
    {
        return await sender.Send(new GetTextoQuestaoByIdQuery() { Id = id });
    }
    #endregion
}
