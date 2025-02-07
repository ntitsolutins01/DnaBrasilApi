using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries;

public class ModeloCarteirinhaDto
{
    public int Id { get; init; }
    public int FomentoId { get; init; }
    public string? NomeImagem { get; set; }
    public string? UrlImagem { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ModeloCarteirinha, ModeloCarteirinhaDto>();
        }
    }
}
