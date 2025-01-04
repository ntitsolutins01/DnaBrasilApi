using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Estruturas.Queries;

public class EstruturaDto
{
    public required int Id { get; init; }
    public required LocalidadeDto Localidade { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Estrutura, EstruturaDto>();
        }
    }
}