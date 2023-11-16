
using DnaBrasil.Application.ConsumosAlimentaresAll.Queries.GetConsumosAlimentaresAllAll;
using DnaBrasil.Application.Laudos.Commands.CreateConsumoAlimentar;
using DnaBrasil.Application.Laudos.Commands.UpdateConsumoAlimentar;
using DnaBrasil.Application.Laudos.Queries;
namespace DnaBrasil.Web.Endpoints;

public class ConsumosAlimentares : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetConsumosAlimentaresAll)
            .MapPost(CreateConsumoAlimentar)
            .MapPut(UpdateConsumoAlimentar, "{id}");

    }

    public async Task<List<ConsumoAlimentarDto>> GetConsumosAlimentaresAll(ISender sender)
    {
        return await sender.Send(new GetConsumosAlimentaresAllQuery());
    }

    public async Task<int> CreateConsumoAlimentar(ISender sender, CreateConsumoAlimentarCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateConsumoAlimentar(ISender sender, int id, UpdateConsumoAlimentarCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
