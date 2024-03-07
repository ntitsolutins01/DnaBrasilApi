using DnaBrasilApi.Application.Alunos.Queries.GetIndicadoresAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Dashboards.Queries.GrafcioControlePresencaByFilter;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Dashboards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(GetIndicadoresByFilter, "Indicadores");
            .MapPost(GetControlePresencaByFilter, "GraficoControlePresencas");
    }

    public Task<DashboardIndicadoresDto> GetIndicadoresByFilter(ISender sender, [FromBody] DashboardIndicadoresDto indicadores)
    {
        var result = new DashboardIndicadoresDto();
        indicadores.AlunosCadastrados = sender.Send(new GetIndicadoresAlunosByFilterQuery(){SearchFilter = indicadores }).Result;
        indicadores.Sexo = "F";
        indicadores.CadastrosFemininos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = indicadores }).Result;
        indicadores.Sexo = "M";
        indicadores.CadastrosMasculinos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = indicadores}).Result;

        return Task.FromResult(indicadores);
    }
    public Task<GraficoControlePresencasDto> GetControlePresencaByFilter(ISender sender, [FromBody] GraficoControlePresencasDto graficoControlePresencas)
    {
        var result = new DashboardIndicadoresDto();
        graficoControlePresencas.ListPresencasAnual = sender.Send(new GrafcioControlePresencaByFilterQuery(){SearchFilter = graficoControlePresencas }).Result;

        graficoControlePresencas.ListFaltasAnual = sender.Send(new GrafcioControlePresencaByFilterQuery() { SearchFilter = graficoControlePresencas }).Result;

        return Task.FromResult(graficoControlePresencas);
    }
}
