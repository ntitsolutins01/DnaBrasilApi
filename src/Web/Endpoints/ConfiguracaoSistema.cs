using DnaBrasilApi.Application.Funcionalidades.Commands.CreateFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Queries;
using DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadesAll;
using DnaBrasilApi.Application.Modulos.Queries.GetModulosAll;
using DnaBrasilApi.Application.Perfis.Commands.CreateModulo;

namespace DnaBrasilApi.Web.Endpoints;

public class ConfiguracaoSistema : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetModulosAll, "Modulos")
            .MapPost(CreateModulo, "Modulo")
            .MapGet(GetFuncionalidadesAll, "Funcionalidades")
            .MapPost(CreateFuncionalidade, "Funcionalidade");
    }

    public async Task<List<ModuloDto>> GetModulosAll(ISender sender)
    {
        return await sender.Send(new GetModulosAllQuery());
    }
    public async Task<int> CreateModulo(ISender sender, CreateModuloCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<List<FuncionalidadeDto>> GetFuncionalidadesAll(ISender sender)
    {
        return await sender.Send(new GetFuncionalidadesAllQuery());
    }
    public async Task<int> CreateFuncionalidade(ISender sender, CreateFuncionalidadeCommand command)
    {
        return await sender.Send(command);
    }
}
