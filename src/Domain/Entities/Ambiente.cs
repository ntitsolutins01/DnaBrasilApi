﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class Ambiente : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public required List<Aluno> Alunos { get; set; }
    public required List<Profissional> Profissionais { get; set; }
}
