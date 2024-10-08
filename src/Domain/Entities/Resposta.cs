﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class Resposta : BaseAuditableEntity
{
    public required string RespostaQuestionario { get; set;}
    public required Questionario Questionario { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public required decimal ValorPesoResposta { get; set; }

}
