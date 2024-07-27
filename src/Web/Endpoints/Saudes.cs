using DnaBrasilApi.Application.Laudos.Commands.CreateSaude;
using DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;


namespace DnaBrasilApi.Web.Endpoints;

public class Saudes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateSaude)
            .MapPut(UpdateSaude, "{id}");
    }

    
    public async Task<int> CreateSaude(ISender sender, CreateSaudeCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateSaude(ISender sender, int id, UpdateSaudeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
