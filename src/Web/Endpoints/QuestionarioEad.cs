using DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadById;
using DnaBrasilApi.Application.QuestionariosEad.Queries;
using DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadAll;
using DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.DeleteQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.UpdateQuestaoEad;

namespace DnaBrasilApi.Web.Endpoints;

public class QuestionariosEad : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetQuestionariosEadAll)
            .MapPost(CreateQuestionarioEad)
            .MapPut(UpdateQuestionarioEad, "{id}")
            .MapDelete(DeleteQuestionarioEad, "{id}")
            .MapGet(GetQuestionarioEadById, "QuestionarioEad/{id}");
    }

    public async Task<List<QuestaoEadDto>> GetQuestionariosEadAll(ISender sender)
    {
        return await sender.Send(new GetQuestionariosEadAllQuery());
    }

    public async Task<QuestaoEadDto> GetQuestionarioEadById(ISender sender, int id)
    {
        return await sender.Send(new GetQuestionarioEadByIdQuery() { Id = id });
    }

    public async Task<int> CreateQuestionarioEad(ISender sender, CreateQuestionarioEadCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateQuestionarioEad(ISender sender, int id, UpdateQuestionarioEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteQuestionarioEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteQuestionarioEadCommand(id));
    }
}
