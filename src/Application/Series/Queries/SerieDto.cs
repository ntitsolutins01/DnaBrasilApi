using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Queries;
public class SerieDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Turma { get; init; }
    public required string NomeEtapaEnsino { get; init; }
    public required int LocalidadeId { get; init; }
    public required string NomeLocalidade { get; init; }
    public string? MunicipioEstado { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>()
                .ForMember(dest => dest.NomeEtapaEnsino, opt => opt.MapFrom(src => src.EtapaEnsino.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade.Nome))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Localidade.Municipio!.Nome!.ToString() + " / " + src.Localidade.Municipio.Estado!.Sigla!.ToString()));
        }
    }
}
