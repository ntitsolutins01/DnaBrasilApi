using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Queries;

public class CertificadoDto
{
    public required int Id { get; init; }
    public required int CursoId { get; init; }
    public required byte[] ImagemFrente { get; init; }
    public byte[]? ImagemVerso { get; init; }
    public string? NomeFotoFrente { get; set; }
    public string? NomeFotoVerso { get; set; }
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
