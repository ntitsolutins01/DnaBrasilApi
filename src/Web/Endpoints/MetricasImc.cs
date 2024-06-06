using DnaBrasilApi.Application.MetricasImc.Commands.CreateMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Commands.DeleteMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;
using DnaBrasilApi.Application.MetricasImc.Queries;
using DnaBrasilApi.Application.MetricasImc.Queries.GetMetricaImcById;
using DnaBrasilApi.Application.MetricasImc.Queries.GetMetricasImcAll;

namespace DnaBrasilApi.Web.Endpoints;

public class MetricasImc : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMetricasImcAll)
            .MapPost(CreateMetricaImc)
            .MapPut(UpdateMetricaImc, "{id}")
            .MapDelete(DeleteMetricaImc, "{id}")
            .MapGet(GetMetricaImcById, "MetricaImc/{id}");
    }

    public async Task<List<MetricaImcDto>> GetMetricasImcAll(ISender sender)
    {
        return await sender.Send(new GetMetricasImcAllQuery());
    }

    public async Task<MetricaImcDto> GetMetricaImcById(ISender sender, int id)
    {
        return await sender.Send(new GetMetricaImcByIdQuery() { Id = id });
    }
    public async Task<int> CreateMetricaImc(ISender sender, CreateMetricaImcCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateMetricaImc(ISender sender, int id, UpdateMetricaImcCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteMetricaImc(ISender sender, int id)
    {
        return await sender.Send(new DeleteMetricaImcCommand(id));
    }
}
