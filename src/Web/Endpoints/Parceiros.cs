using DnaBrasilApi.Application.Parceiros.Commands.CreateParceiro;
using DnaBrasilApi.Application.Parceiros.Commands.DeleteParceiro;
using DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;
using DnaBrasilApi.Application.Parceiros.Queries;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroAll;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroByAspNetUserId;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroById;

namespace DnaBrasilApi.Web.Endpoints;

public class Parceiros : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetParceirosAll)
            .MapPost(CreateParceiro)
            .MapPut(UpdateParceiro, "{id}")
            .MapDelete(DeleteParceiro, "{id}")
            .MapGet(GetParceiroById, "Parceiro/{id}")
            .MapGet(GetParceiroByAspNetUserId, "Parceiro/AspNetUser/{id}");
    }

    public async Task<List<ParceiroDto>> GetParceirosAll(ISender sender)
    {
        return await sender.Send(new GetParceirosAllQuery());
    }

    public async Task<ParceiroDto> GetParceiroById(ISender sender, int id)
    {
        return await sender.Send(new GetParceiroByIdQuery() { Id = id });
    }

    public async Task<ParceiroDto> GetParceiroByAspNetUserId(ISender sender, string aspNetUserId)
    {
        return await sender.Send(new GetParceiroByAspNetUserIdQuery() { AspNetUserId = aspNetUserId });
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
