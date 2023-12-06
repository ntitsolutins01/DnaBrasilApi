using DnaBrasilApi.Application.Fomentos.Commands.CreateFomento;
using DnaBrasilApi.Application.Fomentos.Commands.DeleteFomento;
using DnaBrasilApi.Application.Fomentos.Commands.UpdateFomento;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Application.Fomentos.Queries.GetFomentoById;
using DnaBrasilApi.Application.Fomentos.Queries.GetFomentosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Fomentos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetFomentosAll)
            .MapPost(CreateFomento)
            .MapPut(UpdateFomento, "{id}")
            .MapDelete(DeleteFomento, "{id}")
            .MapGet(GetFomentoById, "Fomento/{id}");
    }

    public async Task<List<FomentoDto>> GetFomentosAll(ISender sender)
    {
        return await sender.Send(new GetFomentosAllQuery());
    }

    public async Task<FomentoDto> GetFomentoById(ISender sender, int id)
    {
        return await sender.Send(new GetFomentoByIdQuery() { Id = id });
    }

    public async Task<int> CreateFomento(ISender sender, CreateFomentoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateFomento(ISender sender, int id, UpdateFomentoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteFomento(ISender sender, int id)
    {
        return await sender.Send(new DeleteFomentoCommand(id));
    }
}
