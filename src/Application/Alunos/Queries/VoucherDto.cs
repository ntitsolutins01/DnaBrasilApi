using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Queries;
public class VoucherDto
{
    public int Id { get; set; }
    public Localidade? Local { get; set; }
    public string? Descricao { get; set; }
    public string? Turma { get; set; }
    public string? Serie { get; set; }
    //public required AlunoDto Aluno { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Voucher, VoucherDto>();
        }
    }
}
