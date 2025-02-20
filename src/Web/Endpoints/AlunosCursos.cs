using DnaBrasilApi.Application.AlunosCursos.Queries.GetAlunoCursoById;
using DnaBrasilApi.Application.AlunosCursos.Commands.CreateAlunoCurso;
using DnaBrasilApi.Application.AlunosCursos.Commands.DeleteAlunoCurso;
using DnaBrasilApi.Application.AlunosCursos.Commands.UpdateAlunoCurso;
using DnaBrasilApi.Application.AlunosCursos.Queries;
using DnaBrasilApi.Application.AlunosCursos.Queries.GetAlunosCursosAll;
using DnaBrasilApi.Application.AlunosCursos.Queries.GetCursosByAlunoId;
using DnaBrasilApi.Application.Cursos.Queries;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de AlunosCursos
/// </summary>
public class AlunosCursos : EndpointGroupBase
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
            .MapGet(GetAlunosCursosAll)
            .MapPost(CreateAlunoCurso)
            .MapPut(UpdateAlunoCurso, "{id}")
            .MapDelete(DeleteAlunoCurso, "{id}")
            .MapGet(GetAlunoCursoById, "{id}")
            .MapGet(GetCursosByAlunoId, "Curso/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da AlunoCurso</param>
    /// <returns>Retorna Id da nova AlunoCurso</returns>
    public async Task<int> CreateAlunoCurso(ISender sender, CreateAlunoCursoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da AlunoCurso</param>
    /// <param name="command">Objeto de alteração da AlunoCurso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAlunoCurso(ISender sender, int id, UpdateAlunoCursoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da AlunoCurso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAlunoCurso(ISender sender, int id)
    {
        return await sender.Send(new DeleteAlunoCursoCommand(id));
    }
    #endregion 

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as AlunosCursos cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de AlunosCursos</returns>
    public async Task<List<AlunoCursoDto>> GetAlunosCursosAll(ISender sender)
    {
        return await sender.Send(new GetAlunosCursosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da AlunoCurso a ser buscada</param>
    /// <returns>Retorna o objeto da AlunoCurso </returns>
    public async Task<AlunoCursoDto> GetAlunoCursoById(ISender sender, int id)
    {
        return await sender.Send(new GetAlunoCursoByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de aulas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do módulo Ead</param>
    /// <returns>Retorna uma lista de AlunosCursos</returns>
    public async Task<List<CursoDto>> GetCursosByAlunoId(ISender sender, int id)
    {
        return await sender.Send(new GetCursosByAlunoIdQuery() { AlunoId = id });
    }
    #endregion
}
