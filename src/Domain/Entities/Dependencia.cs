using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Dependencia : BaseAuditableEntity
{
    public string? Doencas { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Naturalidade { get; set; }
    public string? NomeEscola { get; set; }
    public int TipoEscola { get; set; }
    public int TipoEscolaridade { get; set; }
    public string? Turno { get; set; }
    public string? Serie { get; set; }
    public string? Ano { get; set; }
    public string? Turma { get; set; }
    public bool? TermoCompromisso { get; set; }
    public bool? AutorizacaoUsoImagemAudio { get; set; }
    public bool? AutorizacaoUsoIndicadores { get; set; }
    public bool? AutorizacaoSaida { get; set; } = false;
    public required Aluno Aluno { get; set; }
}
