using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Responsaveis.Queries;

public class ResponsavelDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Cpf { get; init; }
    public required string Telefone { get; init; }
    public string? Email { get; init; }
    public bool Status { get; init; }
    public int? GrauParentescoId { get; init; }
    public string? NomeGrauParentesco { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Responsavel, ResponsavelDto>()
                .ForMember(dest => dest.GrauParentescoId, opt => opt.MapFrom(src => src.GrauParentesco!.Id))
                .ForMember(dest => dest.NomeGrauParentesco, opt => opt.MapFrom(src => src.GrauParentesco!.Nome));
        }
    }
}
