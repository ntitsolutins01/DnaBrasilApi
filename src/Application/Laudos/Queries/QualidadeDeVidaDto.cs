using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Application.Respostas.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class QualidadeDeVidaDto
{
    public int Id { get; init; }
    public int ProfissionalId { get; init; }
    public string? NomeProfissional { get; init; }
    public int AlunoId { get; init; }
    public string? NomeAluno { get; init; }
    public required RespostaDto Resposta { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QualidadeDeVida, QualidadeDeVidaDto>()
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id))
                .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Profissional!.Nome))
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno!.Nome));
        }
    }
}
