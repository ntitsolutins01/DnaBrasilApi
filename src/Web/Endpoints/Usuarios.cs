using DnaBrasilApi.Application.Usuarios.Commands.DeleteUsuario;
using DnaBrasilApi.Application.Usuarios.Commands.UpdateUsuario;
using DnaBrasilApi.Application.Usuarios.Commands.CreateUsuario;
using DnaBrasilApi.Application.Usuarios.Queries;
using DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioById;

namespace DnaBrasilApi.Web.Endpoints;

public class Usuarios : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetUsuariosAll)
            .MapGet(GetUsuarioById, "Usuario/{id}")
            .MapPost(CreateUsuario)
            .MapPut(UpdateUsuario, "{id}")
            .MapDelete(DeleteUsuario, "{id}")
            .MapGet(GetUsuarioByEmail, "Email/{email}")
            .MapGet(GetUsuarioByCpf, "Cpf/{cpf}");
    }

    #region Main Methods

    public async Task<int> CreateUsuario(ISender sender, CreateUsuarioCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateUsuario(ISender sender, int id, UpdateUsuarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteUsuario(ISender sender, int id)
    {
        return await sender.Send(new DeleteUsuarioCommand(id));
    }

    #endregion
    #region Methods

    public async Task<UsuarioDto> GetUsuarioById(ISender sender, int id)
    {
        return await sender.Send(new GetUsuarioByIdQuery() { Id = id });
    }
    public async Task<List<UsuarioDto>> GetUsuariosAll(ISender sender)
    {
        return await sender.Send(new GetUsuariosAllQuery());
    }
    public async Task<UsuarioDto> GetUsuarioByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetUsuarioByEmailQuery() { Email = email });
    }
    public async Task<UsuarioDto> GetUsuarioByCpf(ISender sender, string cpf)
    {
        return await sender.Send(new GetUsuarioByCpfQuery() { Cpf = cpf });
    }

    #endregion 
}
