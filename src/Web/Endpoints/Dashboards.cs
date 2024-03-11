using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Dashboards.Queries.GetIndicadoresAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetLaudosAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GrafcioControlePresencaByFilter;
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

    public Task<DashboardDto> GetDashboardByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.AlunosCadastrados = sender.Send(new GetIndicadoresAlunosByFilterQuery(){SearchFilter = dashboard }).Result;
        dashboard.Sexo = "F";
        dashboard.CadastrosFemininos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard }).Result;
        dashboard.Sexo = "M";
        dashboard.CadastrosMasculinos = sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard}).Result;
        dashboard.Sexo = "";

        dashboard.StatusLaudo= "A";
        dashboard.LaudosAndamentos = sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard }).Result;
        dashboard.StatusLaudo= "F";
        dashboard.LaudosFinalizados = sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard }).Result;
        dashboard.StatusLaudo = "";

        

        dashboard.Sexo = "F";
        dashboard.LaudosFemininos = sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard }).Result;
        dashboard.Sexo = "M";
        dashboard.LaudosMasculinos = sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard }).Result;
        dashboard.Sexo = "";

        dashboard.Controle = "P";
        dashboard.ListPresencasAnual = sender.Send(new GrafcioControlePresencaByFilterQuery(){SearchFilter = dashboard }).Result;
        dashboard.Controle = "F";
        dashboard.ListFaltasAnual = sender.Send(new GrafcioControlePresencaByFilterQuery() { SearchFilter = dashboard }).Result;

        return Task.FromResult(dashboard);
    }
}
