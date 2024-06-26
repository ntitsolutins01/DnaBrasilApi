using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Application.Provas.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Provas.Queries;

public class ProvaDto
{
    public required int Id { get; set; }
    public required Aula Aula { get; set; }
    public required string Titulo { get; set; }
    public bool ProvaRequisito { get; set; }
    public required int Peso { get; set; }
    public required int MediaAprovacao { get; set; }
    public required string LiberacaoProva { get; set; }
    public required DateTime DataLiberacao { get; set; }
    public required TimeSpan DuracaoProva { get; set; }
    public DateTime? DataEncerramento { get; set; }
    public bool PermitirTentativas { get; set; }
    public int Tentativas { get; set; }
    public bool LiberarTentativa { get; set; }
    public bool Status { get; set; }
 
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Prova, ProvaDto>();
        }
    }
}
