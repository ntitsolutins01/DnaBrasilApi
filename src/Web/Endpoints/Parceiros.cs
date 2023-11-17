using DnaBrasil.Application.Parceiros.Commands.CreateParceiro;
using DnaBrasil.Application.Parceiros.Commands.DeleteParceiro;
using DnaBrasil.Application.Parceiros.Commands.UpdateParceiro;
using DnaBrasil.Application.Parceiros.Queries;
using DnaBrasil.Application.Parceiros.Queries.GetParceiroAll;


namespace DnaBrasil.Web.Endpoints;

public class Parceiros : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetParceirosAll)
            .MapPost(CreateParceiro)
            .MapPut(UpdateParceiro, "{id}")
            .MapDelete(DeleteParceiro, "{id}");
    }

    public async Task<List<ParceiroDto>> GetParceirosAll(ISender sender)
    {
        return await sender.Send(new GetParceirosAllQuery());
    }

    public async Task<int> CreateParceiro(ISender sender, CreateParceiroCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateParceiro(ISender sender, int id, UpdateParceiroCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteParceiro(ISender sender, int id)
    {
        return await sender.Send(new DeleteParceiroCommand(id));
    }
}
