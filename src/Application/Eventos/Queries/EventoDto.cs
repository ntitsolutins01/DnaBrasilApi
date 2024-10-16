﻿using DnaBrasilApi.Application.FotosEvento.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Queries;

public class EventoDto
{
    public required int Id { get; set; }
    public required string EstadoId { get; set; }
    public required string Estado { get; set; }
    public required string MunicipioId { get; set; }
    public required string Municipio { get; set; }
    public required string LocalidadeId { get; set; }
    public required string Localidade { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public required string DataEvento { get; set; }
    public bool Status { get; set; }
    public int TotalConvidado { get; set; }
    public int TotalAluno { get; set; }
    public List<FotoEventoDto>? Fotos { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Localidade.Municipio!.Id))
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Localidade.Municipio!.Nome))
                .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Localidade.Municipio!.Estado!.Sigla))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Localidade.Municipio!.Estado!.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade.Id))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade!.Nome))
                .ForMember(dest => dest.TotalAluno, opt => opt.MapFrom(src => src.ControlesPresencas == null ? 0 : src.ControlesPresencas
                    .Where(x => x.Evento != null && x.Evento.Id == src.Id).Count(c=>c.Justificativa == "")))
                .ForMember(dest => dest.TotalConvidado, opt => opt.MapFrom(src => src.ControlesPresencas == null ? 0 :  src.ControlesPresencas
                    .Where(x => x.Evento != null && x.Evento.Id == src.Id).Count(c=>c.Justificativa != "")))
                .ForMember(dest => dest.DataEvento, opt => opt.MapFrom(src => src.DataEvento.ToString("dd/MM/yyyy")));
        }
    }
}
