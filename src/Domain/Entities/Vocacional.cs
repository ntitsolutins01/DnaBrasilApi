﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Vocacional : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required List<Questionario> Questionarios { get; set; }
    public required string Resposta { get; set; }
}
