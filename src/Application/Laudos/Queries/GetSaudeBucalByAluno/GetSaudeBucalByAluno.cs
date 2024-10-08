﻿using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetSaudeBucalByAluno;

public record GetSaudeBucalByAlunoQuery : IRequest<SaudeBucalDto?>
{
    public int AlunoId { get; set; }
}

public class GetSaudeBucalByAlunoQueryHandler : IRequestHandler<GetSaudeBucalByAlunoQuery, SaudeBucalDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSaudeBucalByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SaudeBucalDto?> Handle(GetSaudeBucalByAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        //var laudos = aluno.Laudos!.OrderByDescending(o => o.Created).AsQueryable();

        //var laudoRecente = await laudos
        //    .AsNoTracking()
        //    .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync(cancellationToken);

        var result = await _context.SaudeBucais
            //.Where(x => x.Id == laudoRecente!.SaudeBucalId)
            .AsNoTracking()
            .ProjectTo<SaudeBucalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
