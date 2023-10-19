using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Ambiente : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<Aluno> Alunos { get; } = new();
    public List<Profissional> Profissionais { get; } = new();
}
