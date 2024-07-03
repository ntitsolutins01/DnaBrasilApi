using DnaBrasilApi.Application.Alunos.Commands.CreateDependencia;
using DnaBrasilApi.Application.Alunos.Commands.UpdateDependencia;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetDependenciaById;
using DnaBrasilApi.Application.Alunos.Queries.GetDependenciasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Dependencias : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetDependenciasAll)
            .MapPost(CreateDependencia)
            .MapPut(UpdateDependencia, "{id}")
            //.MapDelete(DeleteDependencia, "{id}")
            .MapGet(GetDependenciaById, "Dependencia/{id}");

    }

    public async Task<List<DependenciaDto>> GetDependenciasAll(ISender sender)
    {
        return await sender.Send(new GetDependenciasAllQuery());
    }

    public async Task<DependenciaDto> GetDependenciaById(ISender sender, int id)
    {
        return await sender.Send(new GetDependenciaByIdQuery { Id = id });
    }
    public async Task<int> CreateDependencia(ISender sender, CreateDependenciaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateDependencia(ISender sender, int id, UpdateDependenciaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    //public async Task<bool> DeleteDependencia(ISender sender, int id)
    //{
    //    return await sender.Send(new DeleteDependenciaCommand(id));
    //}

}
