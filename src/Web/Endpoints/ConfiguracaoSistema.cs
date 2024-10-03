using DnaBrasilApi.Application.Funcionalidades.Commands.CreateFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Commands.DeleteFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Commands.UpdateFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Queries;
using DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadeById;
using DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadesAll;
using DnaBrasilApi.Application.Modulos.Commands.CreateModulo;
using DnaBrasilApi.Application.Modulos.Commands.DeleteModulo;
using DnaBrasilApi.Application.Modulos.Commands.UpdateModulo;
using DnaBrasilApi.Application.Modulos.Queries.GetModuloById;
using DnaBrasilApi.Application.Modulos.Queries.GetModulosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class ConfiguracaoSistema : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetModulosAll, "Modulos")
            .MapGet(GetModuloById, "Modulo/{id}")
            .MapPost(CreateModulo, "Modulo")
            .MapPut(UpdateModulo, "{id}")
            .MapDelete(DeleteModulo, "{id}")
            .MapGet(GetFuncionalidadesAll, "Funcionalidades")
            .MapGet(GetFuncionalidadeById, "Funcionalidade/{id}")
            .MapPost(CreateFuncionalidade, "Funcionalidade")
            .MapPut(UpdateFuncionalidade, "Funcionalidade/{id}")
            .MapDelete(DeleteFuncionalidade, "Funcionalidade/{id}");
    }

    public async Task<int> CreateFuncionalidade(ISender sender, CreateFuncionalidadeCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<bool> UpdateFuncionalidade(ISender sender, int id, UpdateFuncionalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> DeleteFuncionalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteFuncionalidadeCommand(id));
    }
    public async Task<List<FuncionalidadeDto>> GetFuncionalidadesAll(ISender sender)
    {
        return await sender.Send(new GetFuncionalidadesAllQuery());
    }
    public async Task<FuncionalidadeDto> GetFuncionalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetFuncionalidadeByIdQuery() { Id = id });
    }


    public async Task<int> CreateModulo(ISender sender, CreateModuloCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<bool> UpdateModulo(ISender sender, int id, UpdateModuloCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> DeleteModulo(ISender sender, int id)
    {
        return await sender.Send(new DeleteModuloCommand(id));
    }
    public async Task<List<ModuloDto>> GetModulosAll(ISender sender)
    {
        return await sender.Send(new GetModulosAllQuery());
    }

    public async Task<ModuloDto> GetModuloById(ISender sender, int id)
    {
        return await sender.Send(new GetModuloByIdQuery() { Id = id });
    }
}
