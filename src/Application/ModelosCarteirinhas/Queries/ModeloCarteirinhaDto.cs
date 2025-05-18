using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries;

public class ModeloCarteirinhaDto
{
    public int Id { get; init; }
    public int FomentoId { get; init; }
    public string? NomeImagemFrente { get; set; }
    public string? UrlImagemFrente { get; init; }
    public string? NomeImagemVerso { get; set; }
    public string? UrlImagemVerso { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ModeloCarteirinha, ModeloCarteirinhaDto>();
        }
    }
}
