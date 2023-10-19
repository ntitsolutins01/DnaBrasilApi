using DnaBrasil.Application.Alunos.Commands.CreateAluno;

namespace DnaBrasil.Web.Endpoints;

public class Alunos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateAluno);
    }

    public async Task<int> CreateAluno(ISender sender, CreateAlunoCommand command)
    {
        return await sender.Send(command);
    }

}
