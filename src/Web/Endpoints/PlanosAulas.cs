using DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanoAulaById;
using DnaBrasilApi.Application.PlanosAulas.Queries;
using DnaBrasilApi.Application.PlanosAulas.Commands.CreatePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Commands.DeletePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Commands.UpdatePlanoAula;
using DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanosAulasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class PlanosAulas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetPlanosAulasAll)
            .MapPost(CreatePlanoAula)
            .MapPut(UpdatePlanoAula, "{id}")
            .MapDelete(DeletePlanoAula, "{id}")
            .MapGet(GetPlanoAulaById, "PlanoAula/{id}");
    }

    public async Task<List<PlanoAulaDto>> GetPlanosAulasAll(ISender sender)
    {
        return await sender.Send(new GetPlanosAulasAllQuery());
    }

    public async Task<PlanoAulaDto> GetPlanoAulaById(ISender sender, int id)
    {
        return await sender.Send(new GetPlanoAulaByIdQuery() { Id = id });
    }

    public async Task<int> CreatePlanoAula(ISender sender, CreatePlanoAulaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdatePlanoAula(ISender sender, int id, UpdatePlanoAulaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeletePlanoAula(ISender sender, int id)
    {
        return await sender.Send(new DeletePlanoAulaCommand(id));
    }
}
