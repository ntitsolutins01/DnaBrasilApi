﻿using DnaBrasilApi.Application.Alunos.Commands.CreateAluno;
using DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoAmbientes;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoDeficiencias;
using DnaBrasilApi.Application.Alunos.Commands.UpdateVoucher;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;
using DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadesAll;

namespace DnaBrasilApi.Web.Endpoints;
public class Alunos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            //.MapGet(GetAlunosByFilter)
            .MapGet(GetAlunosAll)
            .MapPost(CreateAluno)
            .MapPut(UpdateAluno, "{id}")
            .MapPut(UpdateAlunoAmbientes, "/Ambientes")
            .MapDelete(DeleteAluno, "{id}");
    }

    //public async Task<List<AlunoDto>> GetAlunosByFilter(ISender sender, [FromBody] SearchAlunosDto search)
    //{
    //    return await sender.Send(new GetAlunosByFilterQuery(search));
    //}
    public async Task<List<AlunoDto>> GetAlunosAll(ISender sender)
    {
        return await sender.Send(new GetAlunosAllQuery());
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

    public async Task<IResult> UpdateAlunoDeficiencias(ISender sender, UpdateAlunoDeficienciasCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> UpdateAlunoAmbientes(ISender sender, UpdateAlunoAmbientesCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }
}
