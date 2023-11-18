using DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateVocacional;

namespace DnaBrasilApi.Web.Endpoints;

public class Vocacionais : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateVocacional)
            .MapPut(UpdateVocacional, "{id}");
    }

    public async Task<int> CreateVocacional(ISender sender, CreateVocacionalCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateVocacional(ISender sender, int id, UpdateVocacionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
