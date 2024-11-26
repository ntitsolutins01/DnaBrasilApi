using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Queries;

public class CertificadoDto
{
    public required int Id { get; init; }
    public required int CursoId { get; init; }
    public required Byte[] ImgFrente { get; init; }
    public Byte[]? ImgVerso { get; init; }
    public required string HtmlFrente { get; init; }
    public required string HtmlVerso { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Certificado, CertificadoDto>();
        }
    }
}
