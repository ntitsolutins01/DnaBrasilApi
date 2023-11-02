using DnaBrasil.Application.Usuarios.Commands.CreateUsuario;
using DnaBrasil.Application.Usuarios.Queries.GetUsuarioAll;
using DnaBrasil.Application.Usuarios.Queries.GetUsuariosAll;

namespace DnaBrasil.Web.Endpoints;

public class Usuarios : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUsuariosAll)
            .MapPost(CreateUsuario);
    }

    public async Task<List<UsuarioDto>> GetUsuariosAll(ISender sender)
    {
        return await sender.Send(new GetUsuariosAllQuery());
    }

    public async Task<int> CreateUsuario(ISender sender, CreateUsuarioCommand command)
    {
        return await sender.Send(command);
    }
}
