using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.GruposMateriais.Queries;

public class GrupoMaterialDto
{
    public required int Id { get; init; }
    public required string Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GrupoMaterial, GrupoMaterialDto>();
        }
    }
}
