﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Deficiencia : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
}
