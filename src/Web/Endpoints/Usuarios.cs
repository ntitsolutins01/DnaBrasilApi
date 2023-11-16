using DnaBrasil.Application.Usuarios.Commands.CreateUsuario;
using DnaBrasil.Application.Usuarios.Queries;

namespace DnaBrasil.Web.Endpoints;

public class Usuarios : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetUsuariosAll)
            .MapPost(CreateUsuario)
            .MapGet(GetUsuarioByEmail, "Email/{email}")
            .MapGet(GetUsuarioByCpf, "Cpf/{cpf}");
    }

    public async Task<List<UsuarioDto>> GetUsuariosAll(ISender sender)
    {
        return await sender.Send(new GetUsuariosAllQuery());
    }

    public async Task<int> CreateUsuario(ISender sender, CreateUsuarioCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<UsuarioDto> GetUsuarioByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetUsuarioByEmailQuery() { Email = email });
    }
    public async Task<UsuarioDto> GetUsuarioByCpf(ISender sender, string cpf)
    {
        return await sender.Send(new GetUsuarioByCpfQuery() { Cpf = cpf });
    }
}
