using DnaBrasilApi.Application.Usuarios.Commands.DeleteUsuario;
using DnaBrasilApi.Application.Usuarios.Commands.UpdateUsuario;
using DnaBrasilApi.Application.Usuarios.Commands.CreateUsuario;
using DnaBrasilApi.Application.Usuarios.Queries;
using DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioByCpf;
using DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioByEmail;
using DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioById;
using DnaBrasilApi.Application.Usuarios.Queries.GetUsuariosAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Usuário
/// </summary>
public class Usuarios : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
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
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Usuário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Usuário</param>
    /// <returns>Retorna Id de um novo Usuário</returns>
    public async Task<int> CreateUsuario(ISender sender, CreateUsuarioCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Usuário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Usuário</param>
    /// <param name="command">Objeto de alteração de Usuário</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateUsuario(ISender sender, int id, UpdateUsuarioCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Usuário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Exclusão de Usuário</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteUsuario(ISender sender, int id)
    {
        return await sender.Send(new DeleteUsuarioCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca um único Usuário
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Usuário a ser buscado</param>
    /// <returns>Retorna o objeto do Usuário </returns>
    public async Task<UsuarioDto> GetUsuarioById(ISender sender, int id)
    {
        return await sender.Send(new GetUsuarioByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca todos os Usuário cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Usuário</returns>
    public async Task<List<UsuarioDto>> GetUsuariosAll(ISender sender)
    {
        return await sender.Send(new GetUsuariosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca Usuário por Email
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="email">email</param>
    /// <returns>Retorna a lista por email </returns>
    public async Task<UsuarioDto> GetUsuarioByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetUsuarioByEmailQuery() { Email = email });
    }
    /// <summary>
    /// Endpoint que busca Usuário por Cpf
    /// </summary>
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="cpf">cpf</param>
    /// <returns>retona uma Lista por Cpf</returns>
    public async Task<UsuarioDto> GetUsuarioByCpf(ISender sender, string cpf)
    {
        return await sender.Send(new GetUsuarioByCpfQuery() { Cpf = cpf });
    }
    #endregion
}
