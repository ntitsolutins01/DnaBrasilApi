using DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhaAcaoById;
using DnaBrasilApi.Application.LinhasAcoes.Commands.CreateLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Commands.DeleteLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Commands.UpdateLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Queries;
using DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhasAcoesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class LinhasAcoes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLinhasAcoesAll)
            .MapPost(CreateLinhaAcao)
            .MapPut(UpdateLinhaAcao, "{id}")
            .MapDelete(DeleteLinhaAcao, "{id}")
            .MapGet(GetLinhaAcaoById, "LinhaAcao/{id}");
    }

    public async Task<List<LinhaAcaoDto>> GetLinhasAcoesAll(ISender sender)
    {
        return await sender.Send(new GetLinhasAcoesAllQuery());
    }

    public async Task<LinhaAcaoDto> GetLinhaAcaoById(ISender sender, int id)
    {
        return await sender.Send(new GetLinhaAcaoByIdQuery() { Id = id });
    }

    public async Task<int> CreateLinhaAcao(ISender sender, CreateLinhaAcaoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateLinhaAcao(ISender sender, int id, UpdateLinhaAcaoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteLinhaAcao(ISender sender, int id)
    {
        return await sender.Send(new DeleteLinhaAcaoCommand(id));
    }
}
