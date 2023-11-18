using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Queries;
public class SearchProfissionaisDto
{
    public string? Nome { get; set; }
    public required string Cpf { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
}
