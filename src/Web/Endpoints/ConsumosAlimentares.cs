using DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetConsumoAlimentarById;
using DnaBrasilApi.Application.Laudos.Queries.GetConsumosAlimentaresAll;
using DnaBrasilApi.Application.Laudos.Queries.GetQualidadeVidaById;

namespace DnaBrasilApi.Web.Endpoints;

public class ConsumosAlimentares : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetConsumoAlimentarById, "{id}")
            .MapGet(GetConsumosAlimentaresAll)
            .MapPost(CreateConsumoAlimentar)
            .MapPut(UpdateConsumoAlimentar, "{id}");

    }

    public async Task<ConsumoAlimentarDto> GetConsumoAlimentarById(ISender sender, int id)
    {
        return await sender.Send(new GetConsumoAlimentarByIdQuery() { Id = id });
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
