using DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestaoEadById;
using DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestoesEadAll;
using DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.DeleteQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.UpdateQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Queries;

namespace DnaBrasilApi.Web.Endpoints;

public class QuestoesEad : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetQuestoesEadAll)
            .MapPost(CreateQuestaoEad)
            .MapPut(UpdateQuestaoEad, "{id}")
            .MapDelete(DeleteQuestaoEad, "{id}")
            .MapGet(GetQuestaoEadById, "QuestaoEad/{id}");
    }

    public async Task<List<QuestaoEadDto>> GetQuestoesEadAll(ISender sender)
    {
        return await sender.Send(new GetQuestoesEadAllQuery());
    }

    public async Task<QuestaoEadDto> GetQuestaoEadById(ISender sender, int id)
    {
        return await sender.Send(new GetQuestaoEadByIdQuery() { Id = id });
    }

    public async Task<int> CreateQuestaoEad(ISender sender, CreateQuestaoEadCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateQuestaoEad(ISender sender, int id, UpdateQuestaoEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteQuestaoEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteQuestaoEadCommand(id));
    }
}
