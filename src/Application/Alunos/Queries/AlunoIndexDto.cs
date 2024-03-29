﻿using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoIndexDto
{
    public int Id { get; set; }
    public string? AspNetUserId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? DtNascimento { get; set; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoIndexDto>()
                //.ForMember(dest => dest.AspNetUserId, opt => opt.MapFrom(src => src.AspNetUserId == null : ))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNascimento.ToString("dd/MM/yyyy")));
        }
    }
}
