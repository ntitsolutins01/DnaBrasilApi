using DnaBrasilApi.Infrastructure.Identity;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Users
/// </summary>
public class Users : EndpointGroupBase
{
    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
