using DnaBrasil.Application.Ambientes.Commands.CreateAmbiente;
using DnaBrasil.Application.Ambientes.Commands.DeleteAmbiente;
using DnaBrasil.Application.Ambientes.Commands.UpdateAmbiente;
using DnaBrasil.Application.Ambientes.Queries;
using DnaBrasil.Application.Ambientes.Queries.GetAmbientesAll;

namespace DnaBrasil.Web.Endpoints;

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
