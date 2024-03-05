using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class QualidadeDeVidaDto
{
    public int Id { get; init; }
    public Profissional? Profissional { get; init; }
    public required Aluno Aluno { get; init; }
    public required Resposta Resposta { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QualidadeDeVida, QualidadeDeVidaDto>();
        }
    }
}
