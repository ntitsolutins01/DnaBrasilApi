using DnaBrasilApi.Application.TextosLaudos.Commands.CreateTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Commands.DeleteTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Commands.UpdateTextoLaudo;
using DnaBrasilApi.Application.TextosLaudos.Queries;
using DnaBrasilApi.Application.TextosLaudos.Queries.GetTextoLaudoById;
using DnaBrasilApi.Application.TextosLaudos.Queries.GetTextosLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class TextosLaudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTextosLaudosAll)
            .MapPost(CreateTextoLaudo)
            .MapPut(UpdateTextoLaudo, "{id}")
            .MapDelete(DeleteTextoLaudo, "{id}")
            .MapGet(GetTextoLaudoById, "TextoLaudo/{id}");
    }

    public async Task<List<TextoLaudoDto>> GetTextosLaudosAll(ISender sender)
    {
        return await sender.Send(new GetTextosLaudosAllQuery());
    }

    public async Task<TextoLaudoDto> GetTextoLaudoById(ISender sender, int id)
    {
        return await sender.Send(new GetTextoLaudoByIdQuery() { Id = id });
    }
    public async Task<int> CreateTextoLaudo(ISender sender, CreateTextoLaudoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateTextoLaudo(ISender sender, int id, UpdateTextoLaudoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteTextoLaudo(ISender sender, int id)
    {
        return await sender.Send(new DeleteTextoLaudoCommand(id));
    }
}
