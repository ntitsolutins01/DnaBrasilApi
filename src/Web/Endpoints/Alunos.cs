using DnaBrasil.Application.Common.Models;
using DnaBrasil.Application.Alunos.Commands.CreateAluno;
using DnaBrasil.Application.Alunos.Commands.CreateAlunoDeficiencias;
using DnaBrasil.Application.Alunos.Commands.DeleteAluno;
using DnaBrasil.Application.Alunos.Commands.UpdateAluno;

namespace DnaBrasil.Web.Endpoints;

public class Alunos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateAluno)
            .MapPost(CreateAlunoDeficiencias)
            .MapPut(UpdateAluno, "{id}")
            .MapDelete(DeleteAluno, "{id}");
    }

    public async Task<int> CreateAluno(ISender sender, CreateAlunoCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<int> CreateAlunoDeficiencias(ISender sender, CreateAlunoDeficienciasCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateAluno(ISender sender, int id, UpdateAlunoCommand command)
    {
        if (id != command.AspNetUserId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteAluno(ISender sender, int id)
    {
        await sender.Send(new DeleteAlunoCommand(id));
        return Results.NoContent();
    }
}
