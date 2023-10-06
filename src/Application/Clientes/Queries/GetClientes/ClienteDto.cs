using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Clientes.Queries.GetClientes;
public class ClienteDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            //CreateMap<Cliente, ClienteDto>();
        }
    }
}
