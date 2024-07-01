﻿using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasAll;
using DnaBrasilApi.Application.ControlesPresencas.Commands.CreateControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Commands.DeleteControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Commands.UpdateControlePresenca;
using DnaBrasilApi.Application.ControlesPresencas.Queries;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlePresencaById;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByAlunoId;
using DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByFilter;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class ControlesPresencas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetControlesPresencasAll)
            .MapPost(CreateControlePresenca)
            .MapPut(UpdateControlePresenca, "{id}")
            .MapDelete(DeleteControlePresenca, "{id}")
            .MapGet(GetControlePresencaById, "ControlePresenca/{id}")
            .MapGet(GetControlesPresencasByAlunoId, "ControlePresenca/Aluno/{alunoId}")
            .MapPost(GetControlesPresencasByFilter, "Filter");
    }

    public async Task<ControlesPresencasFilterDto> GetControlesPresencasByFilter(ISender sender, [FromBody] ControlesPresencasFilterDto search)
    {
        var result = await sender.Send(new GetControlesPresencasByFilterQuery() { SearchFilter = search });

        return new ControlesPresencasFilterDto { ControlesPresencas = result };
    }
    public async Task<List<ControlePresencaDto>> GetControlesPresencasAll(ISender sender)
    {
        return await sender.Send(new GetControlesPresencasAllQuery());
    }

    public async Task<ControlePresencaDto> GetControlePresencaById(ISender sender, int id)
    {
        return await sender.Send(new GetControlePresencaByIdQuery() { Id = id });
    }
    public async Task<List<ControlePresencaDto>> GetControlesPresencasByAlunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetControlesPresencasByAlunoIdQuery() { AlunoId = alunoId });
    }
    public async Task<int> CreateControlePresenca(ISender sender, CreateControlePresencaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateControlePresenca(ISender sender, int id, UpdateControlePresencaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteControlePresenca(ISender sender, int id)
    {
        return await sender.Send(new DeleteControlePresencaCommand(id));
    }
}