using DnaBrasilApi.Application.Disciplinas.Queries.GetDisciplinaById;
using DnaBrasilApi.Application.Disciplinas.Commands.CreateDisciplina;
using DnaBrasilApi.Application.Disciplinas.Commands.DeleteDisciplina;
using DnaBrasilApi.Application.Disciplinas.Commands.UpdateDisciplina;
using DnaBrasilApi.Application.Disciplinas.Queries;
using DnaBrasilApi.Application.Disciplinas.Queries.GetDisciplinasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Disciplinas : EndpointGroupBase
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
            .MapGet(GetDisciplinasAll)
            .MapPost(CreateDisciplina)
            .MapPut(UpdateDisciplina, "{id}")
            .MapDelete(DeleteDisciplina, "{id}")
            .MapGet(GetDisciplinaById, "Disciplina/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de disciplina
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da disciplina</param>
    /// <returns>Retorna Id da nova disciplina</returns>
    public async Task<int> CreateDisciplina(ISender sender, CreateDisciplinaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de disciplina
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da disciplina</param>
    /// <param name="command">Objeto de alteração da disciplina</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateDisciplina(ISender sender, int id, UpdateDisciplinaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de disciplina
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da disciplina</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteDisciplina(ISender sender, int id)
    {
        return await sender.Send(new DeleteDisciplinaCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as disciplinas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de disciplinas</returns>
    public async Task<List<DisciplinaDto>> GetDisciplinasAll(ISender sender)
    {
        return await sender.Send(new GetDisciplinasAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única disciplina
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da disciplina a ser buscada</param>
    /// <returns>Retorna o objeto da disciplina </returns>
    public async Task<DisciplinaDto> GetDisciplinaById(ISender sender, int id)
    {
        return await sender.Send(new GetDisciplinaByIdQuery() { Id = id });
    }
    #endregion
}
