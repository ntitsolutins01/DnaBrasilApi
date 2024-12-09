using DnaBrasilApi.Application.Laudos.Commands.CreateSaudeBucal;
using DnaBrasilApi.Application.Laudos.Commands.UpdateSaudeBucal;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetSaudeBucalById;

namespace DnaBrasilApi.Web.Endpoints;

public class SaudeBucais : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetSaudeBucalById, "{id}")
            .MapPost(CreateSaudeBucal)
            .MapPut(UpdateSaudeBucal, "{id}");
    }
    #endregion

    #region Main Methods

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
    #endregion

    #region Methods
    public async Task<SaudeBucalDto> GetSaudeBucalById(ISender sender, int id)
    {
        return await sender.Send(new GetSaudeBucalByIdQuery() { Id = id });
    }
    #endregion
}
