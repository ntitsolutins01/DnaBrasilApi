using DnaBrasilApi.Application.TextosQuestoes.Commands.CreateTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Commands.DeleteTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Commands.UpdateTextoQuestao;
using DnaBrasilApi.Application.TextosQuestoes.Queries;
using DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextoQuestaoById;
using DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextosQuestoesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class TextosQuestoes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTextosQuestoesAll)
            .MapPost(CreateTextoQuestao)
            .MapPut(UpdateTextoQuestao, "{id}")
            .MapDelete(DeleteTextoQuestao, "{id}")
            .MapGet(GetTextoQuestaoById, "TextoQuestao/{id}");
    }

    public async Task<List<TextoQuestaoDto>> GetTextosQuestoesAll(ISender sender)
    {
        return await sender.Send(new GetTextosQuestoesAllQuery());
    }

    public async Task<TextoQuestaoDto> GetTextoQuestaoById(ISender sender, int id)
    {
        return await sender.Send(new GetTextoQuestaoByIdQuery() { Id = id });
    }
    public async Task<int> CreateTextoQuestao(ISender sender, CreateTextoQuestaoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateTextoQuestao(ISender sender, int id, UpdateTextoQuestaoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteTextoQuestao(ISender sender, int id)
    {
        return await sender.Send(new DeleteTextoQuestaoCommand(id));
    }
}
