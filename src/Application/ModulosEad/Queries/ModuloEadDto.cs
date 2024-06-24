using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModulosEad.Queries;

public class ModuloEadDto
{
    public required int Id { get; set; }
    public required int CargaHoraria { get; set; }
    public required int ProfessorId { get; set; }
    public required int CursoId { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ModuloEad, ModuloEadDto>();
        }
    }
}
