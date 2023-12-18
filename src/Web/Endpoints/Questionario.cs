using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioById;
using DnaBrasilApi.Application.Questionarios.Commands.CreateQuestionario;
using DnaBrasilApi.Application.Questionarios.Commands.DeleteQuestionario;
using DnaBrasilApi.Application.Questionarios.Commands.UpdateQuestionario;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioAll;
using DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioByTipoLaudo;

namespace DnaBrasilApi.Web.Endpoints;

public class Questionarios : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetQuestionariosAll)
            .MapPost(CreateQuestionario)
            .MapPut(UpdateQuestionario, "{id}")
            .MapDelete(DeleteQuestionario, "{id}")
            .MapGet(GetQuestionarioByTipoLaudo, "TipoLaudo/{id}")
            .MapGet(GetQuestionarioById, "Questionario/{id}");
    }

    public async Task<List<QuestionarioDto>> GetQuestionarioByTipoLaudo(ISender sender, int id)
    {
        return await sender.Send(new GetQuestionarioByTipoLaudoQuery() { TipoLaudoId = id });
    }

    public async Task<List<QuestionarioDto>> GetQuestionariosAll(ISender sender)
    {
        return await sender.Send(new GetQuestionariosAllQuery());
    }

    public async Task<QuestionarioDto> GetQuestionarioById(ISender sender, int id)
    {
        return await sender.Send(new GetQuestionarioByIdQuery() { Id = id });
    }

    public async Task<int> CreateQuestionario(ISender sender, CreateQuestionarioCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateQuestionario(ISender sender, int id, UpdateQuestionarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteQuestionario(ISender sender, int id)
    {
        return await sender.Send(new DeleteQuestionarioCommand(id));
    }
}
