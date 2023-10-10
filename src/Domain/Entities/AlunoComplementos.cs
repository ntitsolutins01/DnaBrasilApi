using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoComplementos : BaseAuditableEntity
{
    //id aluno
    public string? Doencas { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Naturalidade { get; set; }
    public string? NomeEscola { get; set; }
    // combo TipoEscola
    // combo TipoEscolaridade
    // combo Turno
    public string? Serie { get; set; }
    public string? Ano { get; set; }
    public string? Turma { get; set; }
    public bool TermoCompromisso { get; set; }
    public bool AutUsoDeImagem { get; set; }
    public bool AutCapitacaoEUsoDeIndicadoresDeSaude { get; set; }
    public bool AutSaida { get; set; }
}
