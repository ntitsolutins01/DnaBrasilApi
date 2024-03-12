using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Dashboards.Queries.GetIndicadoresAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetLaudosAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetLaudosPeriodo;
using DnaBrasilApi.Application.Dashboards.Queries.GetStatusLaudosAll;
using DnaBrasilApi.Application.Dashboards.Queries.GrafcioControlePresencaByFilter;
using DnaBrasilApi.Application.Parceiros.Queries.GetParceiroAll;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Dashboards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(GetDashboardByFilter);
    }

    public async Task<DashboardDto> GetDashboardByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.AlunosCadastrados = await sender.Send(new GetIndicadoresAlunosByFilterQuery(){SearchFilter = dashboard });
        dashboard.Sexo = "F";
        dashboard.CadastrosFemininos = await sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "M";
        dashboard.CadastrosMasculinos = await sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard});
        dashboard.Sexo = "";

        dashboard.StatusLaudo= "A";
        dashboard.LaudosAndamentos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.StatusLaudo= "F";
        dashboard.LaudosFinalizados = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.StatusLaudo = "";
        
        dashboard.Sexo = "F";
        dashboard.LaudosFemininos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "M";
        dashboard.LaudosMasculinos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "";

        dashboard.Controle = "P";
        dashboard.ListPresencasAnual = await sender.Send(new GrafcioControlePresencaByFilterQuery(){SearchFilter = dashboard });
        dashboard.Controle = "F";
        dashboard.ListFaltasAnual = await sender.Send(new GrafcioControlePresencaByFilterQuery() { SearchFilter = dashboard });

        dashboard.StatusLaudos = await sender.Send(new GetStatusLaudosAllQuery());

        var laudosPeriodo = await sender.Send(new GetLaudosPeriodoQuery() { SearchFilter = dashboard });

        dashboard.Ultimos3Meses = laudosPeriodo[0];
        dashboard.Ultimos6Meses = laudosPeriodo[1];
        dashboard.Em1Ano = laudosPeriodo[2];

        return await Task.FromResult(dashboard);
    }
}
