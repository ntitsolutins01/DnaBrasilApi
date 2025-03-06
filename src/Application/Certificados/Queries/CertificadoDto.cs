using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Queries;

public class CertificadoDto
{
    public required int Id { get; init; }
    public required int FomentoId { get; init; }
    public required string NomeFomento { get; init; }
    public required string ImagemFrente { get; init; }
    public string? ImagemVerso { get; init; }
    public string? NomeImagemFrente { get; init; }
    public string? NomeImagemVerso { get; init; }
    public required string HtmlFrente { get; init; }
    public required string HtmlVerso { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Certificado, CertificadoDto>()
                .ForMember(dest => dest.ImagemFrente, opt => opt.MapFrom(src => Path.GetFileName(src.ImagemFrente)))
                .ForMember(dest => dest.ImagemVerso, opt => opt.MapFrom(src => Path.GetFileName(src.ImagemVerso)))
                .ForMember(dest => dest.NomeFomento, opt => opt.MapFrom(src => src.Fomento.Nome));
        }
    }
}
