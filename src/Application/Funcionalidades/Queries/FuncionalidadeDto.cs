using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Funcionalidades.Queries;
public class FuncionalidadeDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Funcionalidade, FuncionalidadeDto>();
        }
    }
}
