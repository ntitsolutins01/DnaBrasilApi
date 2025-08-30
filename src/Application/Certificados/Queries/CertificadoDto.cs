using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Queries;

public class CertificadoDto
{
    public required int Id { get; init; }
    public required int FomentoId { get; init; }
    public required string NomeFomento { get; init; }
    public required string Nome { get; set; }
    public required string Url { get; set; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Certificado, CertificadoDto>()
                .ForMember(dest => dest.NomeFomento, opt => opt.MapFrom(src => src.Fomento.Id))
                .ForMember(dest => dest.NomeFomento, opt => opt.MapFrom(src => src.Fomento.Nome));
        }
    }
}
