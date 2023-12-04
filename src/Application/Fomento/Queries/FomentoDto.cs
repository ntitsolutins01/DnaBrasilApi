using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomento.Queries;
public class FomentoDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomento, FomentoDto>();
        }
    }
}
