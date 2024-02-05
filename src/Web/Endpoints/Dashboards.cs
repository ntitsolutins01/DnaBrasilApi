using DnaBrasilApi.Application.Alunos.Queries.GetIndicadoresAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Dashboards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(GetIndicadoresByFilter, "Indicadores");
    }

    public Task<DashboardIndicadoresDto> GetIndicadoresByFilter(ISender sender, [FromBody] DashboardIndicadoresDto indicadores)
    {
        var result = new DashboardIndicadoresDto();
        indicadores.AlunosCadastrados = sender.Send(new GetIndicadoresAlunosByFilterQuery(){SearchFilter = indicadores }).Result;
        indicadores.Sexo = "M";
        indicadores.CadastrosFemininos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = indicadores }).Result;
        indicadores.Sexo = "F";
        indicadores.CadastrosMasculinos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = indicadores}).Result;

        return Task.FromResult(indicadores);
    }
}
