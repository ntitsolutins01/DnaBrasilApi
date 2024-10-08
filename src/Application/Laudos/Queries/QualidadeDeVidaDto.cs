using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Application.Respostas.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class QualidadeDeVidaDto
{
    public int Id { get; init; }
    //public required Profissional Profissional { get; set; }
    //public required Aluno Aluno { get; set; }
    public string? Encaminhamentos { get; set; }
    public required string Respostas { get; set; }
    public string? StatusQualidadeDeVida { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QualidadeDeVida, QualidadeDeVidaDto>();
        }
    }
}
