using DnaBrasilApi.Application.Cursos.Queries.GetCursoById;
using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Application.Cursos.Commands.CreateCurso;
using DnaBrasilApi.Application.Cursos.Commands.DeleteCurso;
using DnaBrasilApi.Application.Cursos.Commands.UpdateCurso;
using DnaBrasilApi.Application.Cursos.Queries.GetCursosAll;
using DnaBrasilApi.Application.Cursos.Queries.GetCursosAllByTipoCursoId;

namespace DnaBrasilApi.Web.Endpoints;

public class Cursos : EndpointGroupBase
{
    #region MapEndpoints

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetCursosAll)
            .MapPost(CreateCurso)
            .MapPut(UpdateCurso, "{id}")
            .MapDelete(DeleteCurso, "{id}")
            .MapGet(GetCursoById, "Curso/{id}")
            .MapGet(GetCursosAllByTipoCursoId, "Curso/TipoCurso/{tipoCursoId}");
    }

    #endregion

    #region Main Methods

    public async Task<int> CreateCurso(ISender sender, CreateCursoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateCurso(ISender sender, int id, UpdateCursoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteCurso(ISender sender, int id)
    {
        return await sender.Send(new DeleteCursoCommand(id));
    }

    #endregion

    #region Methods

    public async Task<List<CursoDto>> GetCursosAll(ISender sender)
    {
        return await sender.Send(new GetCursosAllQuery());
    }

    public async Task<CursoDto> GetCursoById(ISender sender, int id)
    {
        return await sender.Send(new GetCursoByIdQuery() { Id = id });
    }
    public async Task<List<CursoDto>> GetCursosAllByTipoCursoId(ISender sender, int tipoCursoId)
    {
        return await sender.Send(new GetCursosAllByTipoCursoIdQuery() { TipoCursoId = tipoCursoId });
    }

    #endregion
}
