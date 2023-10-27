using DnaBrasil.Application.Alunos.Commands.CreateAluno;
using DnaBrasil.Application.Alunos.Commands.CreateMatricula;
using DnaBrasil.Application.Alunos.Commands.CreateVoucher;
using DnaBrasil.Application.Alunos.Commands.DeleteAluno;
using DnaBrasil.Application.Alunos.Commands.UpdateAluno;
using DnaBrasil.Application.Alunos.Commands.UpdateAlunoAmbientes;
using DnaBrasil.Application.Alunos.Commands.UpdateMatricula;
using DnaBrasil.Application.Alunos.Commands.UpdateVoucher;
using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Alunos.Queries.GetAlunosByFilter;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasil.Web.Endpoints;
public class Alunos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetAlunosByFilter)
            .MapPost(CreateAluno)
            .MapPut(UpdateAluno, "{id}")
            .MapPut(UpdateAlunoAmbientes, "/Ambientes")
            .MapDelete(DeleteAluno, "{id}")
            .MapPost(CreateMatricula, "Matricula")
            .MapPut(UpdateMatricula, "/Matricula/{id}")
            .MapPost(CreateVoucher, "Voucher")
            .MapPut(UpdateVoucher, "/Voucher/{id}");
    }

    public async Task<List<AlunoDto>> GetAlunosByFilter(ISender sender, [FromBody] SearchAlunosDto search)
    {
        return await sender.Send(new GetAlunosByFilterQuery(search));
    }

    public async Task<int> CreateAluno(ISender sender, CreateAlunoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateAluno(ISender sender, int id, UpdateAlunoCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteAluno(ISender sender, int id)
    {
        await sender.Send(new DeleteAlunoCommand(id));
        return Results.NoContent();
    }
    public async Task<IResult> UpdateMatricula(ISender sender, int id, UpdateMatriculaCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<int> CreateMatricula(ISender sender, CreateMatriculaCommand command)
    {
        return await sender.Send(command);
    }

    //public async Task<int> CreateDependencia(ISender sender, CreateDependenciaCommand command)
    //{
    //    return await sender.Send(command);
    //}

    public async Task<int> CreateVoucher(ISender sender, CreateVoucherCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateVoucher(ISender sender, int id, UpdateVoucherCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateAlunoAmbientes(ISender sender, UpdateAlunoAmbientesCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
