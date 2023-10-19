using DnaBrasil.Application.Municipios.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Profissionais.Queries.ProfissionalByFilter;
public class SearchProfissionaisDto
{
    public string? Nome { get; set; }
    public required string Cpf { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
}
