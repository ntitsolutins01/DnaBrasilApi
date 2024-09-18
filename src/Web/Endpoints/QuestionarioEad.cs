using DnaBrasilApi.Application.QuestionarioEadsEad.Commands.CreateQuestionarioEad;
using DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadById;
using DnaBrasilApi.Application.QuestionariosEad.Commands.DeleteQuestionarioEad;
using DnaBrasilApi.Application.QuestionariosEad.Commands.UpdateQuestionarioEad;
using DnaBrasilApi.Application.QuestionariosEad.Queries;
using DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadAll;

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

    public async Task<List<QuestionarioEadDto>> GetQuestionariosEadAll(ISender sender)
    {
        return await sender.Send(new GetQuestionariosEadAllQuery());
    }

    public async Task<QuestionarioEadDto> GetQuestionarioEadById(ISender sender, int id)
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
