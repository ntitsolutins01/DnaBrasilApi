using DnaBrasilApi.Application.Cursos.Queries.GetCursoById;
using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Application.Cursos.Commands.CreateCurso;
using DnaBrasilApi.Application.Cursos.Commands.DeleteCurso;
using DnaBrasilApi.Application.Cursos.Commands.UpdateCurso;
using DnaBrasilApi.Application.Cursos.Queries.GetCursosAll;
using DnaBrasilApi.Application.Cursos.Queries.GetCursosAllByTipoCursoId;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Curso
/// </summary>
public class Cursos : EndpointGroupBase
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
            .MapGet(GetCursosAll)
            .MapPost(CreateCurso)
            .MapPut(UpdateCurso, "{id}")
            .MapDelete(DeleteCurso, "{id}")
            .MapGet(GetCursoById, "{id}")
            .MapGet(GetCursosAllByTipoCursoId, "TipoCurso/{tipoCursoId}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Curso</param>
    /// <returns>Retorna Id de novo Curso</returns>
    public async Task<int> CreateCurso(ISender sender, CreateCursoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Curso</param>
    /// <param name="command">Objeto de alteração de Curso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateCurso(ISender sender, int id, UpdateCursoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de Curso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteCurso(ISender sender, int id)
    {
        return await sender.Send(new DeleteCursoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Cursos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Cursos</returns>
    public async Task<List<CursoDto>> GetCursosAll(ISender sender)
    {
        return await sender.Send(new GetCursosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Curso a ser buscado</param>
    /// <returns>Retorna o objeto de Curso </returns>
    public async Task<CursoDto> GetCursoById(ISender sender, int id)
    {
        return await sender.Send(new GetCursoByIdQuery() { Id = id });
    }
    /// <summary>
    ///  Endpoint que busca todos os Cursos por id 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="tipoCursoId">tipoCursoid</param>
    /// <returns>Retorna a lista por Curso id</returns>
    public async Task<List<CursoDto>> GetCursosAllByTipoCursoId(ISender sender, int tipoCursoId)
    {
        return await sender.Send(new GetCursosAllByTipoCursoIdQuery() { TipoCursoId = tipoCursoId });
    }
    #endregion
}
