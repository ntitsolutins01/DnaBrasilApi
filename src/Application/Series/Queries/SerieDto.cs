using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Queries;
public class SerieDto
{
    public int Id { get; init; }
    public required string Nome { get; set; }
    public required string Turma { get; set; }
    public required string NomeEtapaEnsino { get; set; }
    public required int LocalidadeId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>()
                .ForMember(dest => dest.NomeEtapaEnsino, opt => opt.MapFrom(src => src.EtapaEnsino.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade.Id));
        }
    }
}
