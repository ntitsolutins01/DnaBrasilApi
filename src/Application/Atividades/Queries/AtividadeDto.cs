using System;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Queries;

public class AtividadeDto
{
    public required int Id { get; init; }
    public required int EstruturaId { get; init; }
    public required string NomeEstrutura { get; init; }
    public required int LinhaAcaoId { get; init; }
    public required string NomeLinhaAcao { get; init; }
    public required int CategoriaId { get; init; }
    public required string NomeCategoria { get; init; }
    public required int ModalidadeId { get; init; }
    public required string NomeModalidade { get; init; }
    public required string Turma { get; init; }
    public required string DiasSemana { get; init; }
    public required string HrInicial { get; init; }
    public required string HrFinal { get; init; }
    public required int ProfissionalId { get; init; }
    public required string NomeProfissional { get; init; }
    public required int LocalidadeId { get; init; }
    public required string NomeLocalidade { get; init; }
    public bool Status { get; init; }
    public required string TurmaHora { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Atividade, AtividadeDto>()
                .ForMember(dest => dest.EstruturaId, opt => opt.MapFrom(src => src.Estrutura!.Id))
                .ForMember(dest => dest.NomeEstrutura, opt => opt.MapFrom(src => src.Estrutura!.Nome))
                .ForMember(dest => dest.LinhaAcaoId, opt => opt.MapFrom(src => src.LinhaAcao!.Id))
                .ForMember(dest => dest.NomeLinhaAcao, opt => opt.MapFrom(src => src.LinhaAcao!.Nome))
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.Categoria!.Id))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria!.Nome))
                .ForMember(dest => dest.ModalidadeId, opt => opt.MapFrom(src => src.Modalidade!.Id))
                .ForMember(dest => dest.NomeModalidade, opt => opt.MapFrom(src => src.Modalidade!.Nome))
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id))
                .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Profissional!.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade!.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade!.Nome))
                .ForMember(dest => dest.HrInicial,
                    opt => opt.MapFrom(src => new DateTime(src.HrInicial.Ticks).ToString("HH:mm")))
                .ForMember(dest => dest.HrFinal,
                    opt => opt.MapFrom(src => new DateTime(src.HrFinal.Ticks).ToString("HH:mm")))
                .ForMember(dest => dest.TurmaHora,
                    opt => opt.MapFrom(src =>
                        src.Turma + " - " + new DateTime(src.HrInicial.Ticks).ToString("HH:mm") + " - " +
                        new DateTime(src.HrFinal.Ticks).ToString("HH:mm")));
        }
    }
}
