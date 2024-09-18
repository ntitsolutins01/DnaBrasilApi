using DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Commands.DeleteRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;
using DnaBrasilApi.Application.RespostasEad.Queries;
using DnaBrasilApi.Application.RespostasEad.Queries.GetRespostaEadAll;
using DnaBrasilApi.Application.RespostasEad.Queries.GetRespostaEadById;

namespace DnaBrasilApi.Web.Endpoints;

public class RespostasEad : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetRespostasEadAll)
            .MapPost(CreateRespostaEad)
            .MapPut(UpdateRespostaEad, "{id}")
            .MapDelete(DeleteRespostaEad, "{id}")
            .MapGet(GetRespostaEadById, "RespostaEad/{id}");
    }

    public async Task<List<RespostaEadDto>> GetRespostasEadAll(ISender sender)
    {
        return await sender.Send(new GetRespostasEadAllQuery());
    }

    public async Task<RespostaEadDto> GetRespostaEadById(ISender sender, int id)
    {
        return await sender.Send(new GetRespostaEadByIdQuery() { Id = id });
    }

    public async Task<int> CreateRespostaEad(ISender sender, CreateRespostaEadCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateRespostaEad(ISender sender, int id, UpdateRespostaEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteRespostaEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteRespostaEadCommand(id));
    }
}
