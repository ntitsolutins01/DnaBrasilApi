using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Commands.CreateTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Commands.UpdateTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Queries;
using DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoByAluno;
using DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoById;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Talentos Esportivos
/// </summary>
public class TalentosEsportivos : EndpointGroupBase
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
            .MapPost(CreateTalentoEsportivo)
            .MapPut(UpdateTalentoEsportivo, "{id}")
            .MapGet(GetTalentoEsportivoByIdQuery, "{id}")
            .MapGet(GetTalentoEsportivoByAlunoQuery, "Aluno/{alunoId}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Talento Esportivo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Talento Esportivo</param>
    /// <returns>Retorna Id de novo Talento Esportivo</returns>
    public async Task<int> CreateTalentoEsportivo(ISender sender, CreateTalentoEsportivoCommand command)
    {
        var result = await sender.Send(command);

        var updateResult = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(command.AlunoId));

        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Talento Esportivo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Talento Esportivo</param>
    /// <param name="command">Objeto de alteração de Talento Esportivo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTalentoEsportivo(ISender sender, int id, UpdateTalentoEsportivoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        var updateResult = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(command.AlunoId));

        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca Talento Esportivo por Aluno Consulta
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="alunoId">alunoid</param>
    /// <returns>Retorna uma lista de Talento Esportivo</returns>
    public async Task<TalentoEsportivoDto> GetTalentoEsportivoByAlunoQuery(ISender sender, int alunoId)
    {
        return await sender.Send(new GetTalentoEsportivoByAlunoQuery(alunoId));
    }
    /// <summary>
    /// Endpoint que busca Talento Esportivo por id de Consulta
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">Id de Talento Esportivo por Consulta a ser buscada</param>
    /// <returns>Retorna uma lista de Talento Esportivo por id de Consulta</returns>
    public async Task<TalentoEsportivoDto> GetTalentoEsportivoByIdQuery(ISender sender, int id)
    {
        return await sender.Send(new GetTalentoEsportivoByIdQuery(id));
    }
    #endregion
}
