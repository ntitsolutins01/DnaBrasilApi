﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Serie : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
}
