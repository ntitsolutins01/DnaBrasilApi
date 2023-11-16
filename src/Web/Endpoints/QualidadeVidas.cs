using DnaBrasil.Application.Laudos.Commands.CreateQualidadeDeVida;
using DnaBrasil.Application.Laudos.Commands.UpdateQualidadeDeVida;

namespace DnaBrasil.Web.Endpoints;

public class QualidadeDeVidas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateQualidadeDeVida)
            .MapPut(UpdateQualidadeDeVida, "{id}");

    }

    

    public async Task<int> CreateQualidadeDeVida(ISender sender, CreateQualidadeDeVidaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateQualidadeDeVida(ISender sender, int id, UpdateQualidadeDeVidaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
