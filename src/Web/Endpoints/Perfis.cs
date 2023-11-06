using System.Collections;
using System.Security.Claims;
using DnaBrasil.Application.Perfis.Commands.CreatePerfil;
using DnaBrasil.Application.Perfis.Queries.GetPerfisAll;
using DnaBrasil.Web.Dto;
using DnaBrasil.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfilDto = DnaBrasil.Application.Perfis.Queries.PerfilDto;

namespace DnaBrasil.Web.Endpoints;

public class Perfis : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetPerfisAll)
            .MapPost(CreatePerfil);
    }

    public async Task<List<PerfilDto>> GetPerfisAll(ISender sender)
    {
        return await sender.Send(new GetPerfisAllQuery());
    }

    public async Task<int> CreatePerfil(ISender sender, CreatePerfilCommand command)
    {
        return await sender.Send(command);
    }
}
