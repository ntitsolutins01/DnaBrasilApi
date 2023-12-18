using DnaBrasilApi.Application.Respostas.Queries.GetRespostaById;
using DnaBrasilApi.Application.Respostas.Commands.CreateResposta;
using DnaBrasilApi.Application.Respostas.Commands.DeleteResposta;
using DnaBrasilApi.Application.Respostas.Commands.UpdateResposta;
using DnaBrasilApi.Application.Respostas.Queries;
using DnaBrasilApi.Application.Respostas.Queries.GetRespostaAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Respostas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetRespostasAll)
            .MapPost(CreateResposta)
            .MapPut(UpdateResposta, "{id}")
            .MapDelete(DeleteResposta, "{id}")
            .MapGet(GetRespostaById, "Resposta/{id}");
    }

    public async Task<List<RespostaDto>> GetRespostasAll(ISender sender)
    {
        return await sender.Send(new GetRespostasAllQuery());
    }

    public async Task<RespostaDto> GetRespostaById(ISender sender, int id)
    {
        return await sender.Send(new GetRespostaByIdQuery() { Id = id });
    }

    public async Task<int> CreateResposta(ISender sender, CreateRespostaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateResposta(ISender sender, int id, UpdateRespostaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteResposta(ISender sender, int id)
    {
        return await sender.Send(new DeleteRespostaCommand(id));
    }
}
