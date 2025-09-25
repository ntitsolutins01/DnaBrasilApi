using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoTurmaDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public bool Status { get; init; }
    public bool Habilitado { get; init; }
    public string? SerieTurma { get; init; }
    public string? SerieId { get; init; }
    public string? EtapaId { get; init; }
    public string? SerieNome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoTurmaDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToUpper()))
                .ForMember(dest => dest.SerieTurma,
                    opt => opt.MapFrom(src => src.Serie!.Nome + " - " + src.Serie!.Turma))
                .ForMember(dest => dest.SerieId, opt => opt.MapFrom(src => src.Serie!.Id))
                .ForMember(dest => dest.SerieNome, opt => opt.MapFrom(src => src.Serie!.Nome))
                .ForMember(dest => dest.EtapaId, opt => opt.MapFrom(src => src.Serie!.EtapaEnsino.Id));
        }
    }
}
