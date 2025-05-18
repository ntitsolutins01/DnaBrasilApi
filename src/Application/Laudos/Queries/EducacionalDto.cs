using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Series.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class EducacionalDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public required AlunoDto Aluno { get; init; }
    public required SerieDto Serie { get; init; }
    public required string Pdf { get; init; }
    public required string Respostas { get; init; }
    public EncaminhamentoDto? Encaminhamento { get; init; }
    public string? StatusEducacional { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Educacional, EducacionalDto>();
        }
    }
}
