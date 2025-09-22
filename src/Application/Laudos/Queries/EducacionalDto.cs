using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class EducacionalDto
{
    public int Id { get; init; }
    public required string ProfissionalId { get; init; }
    public required string AlunoId { get; init; }
    public required string Gabarito { get; init; }
    public required string Respostas { get; init; }
    public string? EncaminhamentoId { get; init; }
    public string? StatusEducacional { get; init; }
    public string? Imagem { get; init; }
    public string? NomeImagem { get; init; }
    public DateTimeOffset? DataCriacao { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Educacional, EducacionalDto>()
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.Created));
        }
    }
}
