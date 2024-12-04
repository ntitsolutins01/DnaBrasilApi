using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoIndexDto
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? Email { get; init; }
    public string? DtNascimento { get; init; }
    public string? MunicipioId { get; init; }
    public bool Status { get; init; }
    public bool Convidado { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoIndexDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Id +"-"+ src.Nome.ToUpper()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio.Id))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNascimento.ToString("dd/MM/yyyy")));
        }
    }
}
