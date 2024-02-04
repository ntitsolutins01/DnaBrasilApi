using DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Dashboards.Queries.GetAlunosBySexo;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Dashboards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetIndicadoresByFilter, "Indicadores");
    }

    public Task<DashboardIndicadoresDto> GetIndicadoresByFilter(ISender sender)
    {
        var result = new DashboardIndicadoresDto();
        result.AlunosCadastrados = sender.Send(new GetAlunosBySexoQuery()).Result;
        result.CadastrosFemininos = sender.Send(new GetAlunosBySexoQuery() { Sexo = "F" }).Result;
        result.CadastrosMasculinos = sender.Send(new GetAlunosBySexoQuery() { Sexo = "M" }).Result;

        return Task.FromResult(result);
    }
}
