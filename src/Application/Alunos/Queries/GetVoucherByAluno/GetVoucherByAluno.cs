using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetVoucherByAluno;

public record GetVoucherByAlunoQuery : IRequest<VoucherDto>
{
    public int AlunoId { get; set; }
}

public class GetVoucherByAlunoQueryHandler : IRequestHandler<GetVoucherByAlunoQuery, VoucherDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVoucherByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VoucherDto> Handle(GetVoucherByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result!.Voucher == null ? throw new ArgumentNullException(nameof(result.Voucher)) : result.Voucher;
    }
}
