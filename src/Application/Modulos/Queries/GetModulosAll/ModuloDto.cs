using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Modulos.Queries.GetModulosAll;
public class ModuloDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Modulo, ModuloDto>();
        }
    }
}
