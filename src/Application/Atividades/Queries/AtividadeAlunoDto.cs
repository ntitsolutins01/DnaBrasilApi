using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Queries;

public class AtividadeAlunoDto
{
    public required string AlunoId { get; init; }
    public required string Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AtividadeAluno, AtividadeAlunoDto>()
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.AlunoId.ToString()))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Aluno!.Nome));
        }
    }
}
