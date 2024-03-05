using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class QualidadeDeVida : BaseAuditableEntity
{
    public Profissional? Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public required Resposta Resposta { get; set; }
}
