using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoIndexDto
{
    public int Id { get; set; }
    public string? AspNetUserId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? DtNascimento { get; set; }
    public string? MunicipioId { get; set; }
    public bool Status { get; set; }
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
