using DnaBrasil.Application.Alunos.Commands.CreateMatricula;
using DnaBrasil.Application.Alunos.Commands.UpdateMatricula;
using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Alunos.Queries.GetMatriculasAll;

namespace DnaBrasil.Web.Endpoints;

public class Matriculas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMatriculasAll)
            .MapPost(CreateMatricula)
            .MapPut(UpdateMatricula, "{id}");

    }

    public async Task<List<MatriculaDto>> GetMatriculasAll(ISender sender)
    {
        return await sender.Send(new GetMatriculasAllQuery());
    }

    public async Task<int> CreateMatricula(ISender sender, CreateMatriculaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateMatricula(ISender sender, int id, UpdateMatriculaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
