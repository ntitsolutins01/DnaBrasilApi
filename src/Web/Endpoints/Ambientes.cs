using DnaBrasilApi.Application.Ambientes.Commands.CreateAmbiente;
using DnaBrasilApi.Application.Ambientes.Commands.DeleteAmbiente;
using DnaBrasilApi.Application.Ambientes.Commands.UpdateAmbiente;
using DnaBrasilApi.Application.Ambientes.Queries;
using DnaBrasilApi.Application.Ambientes.Queries.GetAmbientesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Ambientes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetAmbientesAll)
            .MapPost(CreateAmbiente)
            .MapPut(UpdateAmbiente, "{id}")
            .MapDelete(DeleteAmbiente, "{id}");
    }

    public async Task<List<AmbienteDto>> GetAmbientesAll(ISender sender)
    {
        return await sender.Send(new GetAmbientesQuery());
    }

    public async Task<int> CreateAmbiente(ISender sender, CreateAmbienteCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateAmbiente(ISender sender, int id, UpdateAmbienteCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteAmbiente(ISender sender, int id)
    {
        return await sender.Send(new DeleteAmbienteCommand(id));
    }
}
