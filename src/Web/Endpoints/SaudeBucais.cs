using DnaBrasil.Application.Laudos.Commands.CreateSaudeBucal;
using DnaBrasil.Application.Laudos.Commands.UpdateSaudeBucal;

namespace DnaBrasil.Web.Endpoints;

public class SaudeBucais : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateSaudeBucal)
            .MapPut(UpdateSaudeBucal, "{id}");
    }


    public async Task<int> CreateSaudeBucal(ISender sender, CreateSaudeBucalCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateSaudeBucal(ISender sender, int id, UpdateSaudeBucalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
