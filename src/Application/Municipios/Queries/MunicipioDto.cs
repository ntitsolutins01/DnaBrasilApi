using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Municipios.Queries.GetMunicipiosAll;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Municipios.Queries;

public class MunicipioDto
{
    public int Id { get; init; }
    public int Codigo { get; init; }
    public string? Nome { get; init; }
    public Estado? Estado { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Municipio, MunicipioDto>();
        }
    }
}
