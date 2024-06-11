using DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursoById;
using DnaBrasilApi.Application.TipoCursos.Queries;
using DnaBrasilApi.Application.TipoCursos.Commands.CreateTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Commands.DeleteTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Commands.UpdateTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class TiposCursos : EndpointGroupBase
{
    #region MapEndpoints

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTiposCursosAll)
            .MapPost(CreateTipoCurso)
            .MapPut(UpdateTipoCurso, "{id}")
            .MapDelete(DeleteTipoCurso, "{id}")
            .MapGet(GetTipoCursoById, "TipoCurso/{id}");
    }

    #endregion

    #region Main Methods

    public async Task<int> CreateTipoCurso(ISender sender, CreateTipoCursoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateTipoCurso(ISender sender, int id, UpdateTipoCursoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteTipoCurso(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoCursoCommand(id));
    }

    #endregion

    #region Methods

    public async Task<List<TipoCursoDto>> GetTiposCursosAll(ISender sender)
    {
        return await sender.Send(new GetTipoCursosAllQuery());
    }

    public async Task<TipoCursoDto> GetTipoCursoById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoCursoByIdQuery() { Id = id });
    }

    #endregion
}
