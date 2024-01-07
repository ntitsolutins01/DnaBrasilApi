using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Laudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLaudosAll);
    }

    public async Task<List<LaudoDto>> GetLaudosAll(ISender sender)
    {
        return await sender.Send(new GetLaudosAllQuery());
    }
}
