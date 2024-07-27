using DnaBrasilApi.Application.Funcionalidades.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Modulos.Queries.GetModulosAll;
public class ModuloDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public List<FuncionalidadeDto>? Funcionalidades { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Modulo, ModuloDto>();
        }
    }
}
