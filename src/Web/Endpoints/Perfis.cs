using Azure.Core;
using DnaBrasilApi.Application.Perfis.Commands.CreatePerfil;
using DnaBrasilApi.Application.Perfis.Commands.DeletePerfil;
using DnaBrasilApi.Application.Perfis.Commands.UpdatePerfil;
using DnaBrasilApi.Application.Perfis.Queries;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfilByAspNetRoleId;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfilById;
using DnaBrasilApi.Application.Perfis.Queries.GetPerfisAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Perfis : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetPerfisAll)
            .MapGet(GetPerfilByAspNetRoleId, "AspNetRoleId/{aspNetRoleId}")
            .MapGet(GetPerfilById, "{id}")
            .MapPost(CreatePerfil)
            .MapPut(UpdatePerfil, "{id}")
            .MapDelete(DeletePerfil, "{id}");
    }

    public async Task<List<PerfilDto>> GetPerfisAll(ISender sender)
    {
        return await sender.Send(new GetPerfisAllQuery());
    }

    public async Task<PerfilDto> GetPerfilByAspNetRoleId(ISender sender, string aspNetRoleId)
    {
        return await sender.Send(new GetPerfilByAspNetRoleIdQuery
        {
            AspNetRoleId = aspNetRoleId
        });
    }

    public async Task<PerfilDto> GetPerfilById(ISender sender, int id)
    {
        return await sender.Send(new GetPerfilByIdQuery { Id = id });
    }

    public async Task<int> CreatePerfil(ISender sender, CreatePerfilCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdatePerfil(ISender sender, int id, UpdatePerfilCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeletePerfil(ISender sender, int id)
    {
        return await sender.Send(new DeletePerfilCommand(id));
    }
}
