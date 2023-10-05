using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Series.Querries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Locais.Queries;
public class LocaisDto
{
    public int Id { get; init; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? CidadeId { get; set; }
    public string? EstadId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Local, LocaisDto>();
        }
    }
}
