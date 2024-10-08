using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.LinhasAcoes.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Modalidades.Queries;
public class ModalidadeDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Vo2MaxIni { get; set; }
    public int Vo2MaxFim { get; set; }
    public int VinteMetrosIni { get; set; }
    public int VinteMetrosFim { get; set; }
    public int ShutlleRunIni { get; set; }
    public int ShutlleRunFim { get; set; }
    public int FlexibilidadeIni { get; set; }
    public int FlexibilidadeFim { get; set; }
    public int PreensaoManualIni { get; set; }
    public int PreensaoManualFim { get; set; }
    public int AbdominalPranchaIni { get; set; }
    public int AbdominalPranchaFim { get; set; }
    public int ImpulsaoIni { get; set; }
    public int ImpulsaoFim { get; set; }
    public int EnvergaduraIni { get; set; }
    public int EnvergaduraFim { get; set; }
    public int PesoIni { get; set; }
    public int PesoFim { get; set; }
    public int AlturaIni { get; set; }
    public int AlturaFim { get; set; }
    public bool Status { get; set; } = true;
    public LinhaAcaoDto? LinhaAcao { get; set; }
    public byte[]? ByteImage { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Modalidade, ModalidadeDto>();
        }
    }
}
