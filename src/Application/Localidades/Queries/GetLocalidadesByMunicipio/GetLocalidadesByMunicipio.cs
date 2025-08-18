using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByMunicipio;

public record GetLocalidadesByMunicipioQuery : IRequest<List<LocalidadeDto>>
{
    public required int Id { get; init; }
}

public class GetLocalidadesByMunicipioQueryHandler : IRequestHandler<GetLocalidadesByMunicipioQuery, List<LocalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IUser _user;

    public GetLocalidadesByMunicipioQueryHandler(IApplicationDbContext context, IMapper mapper, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _user = user;
    }

    public async Task<List<LocalidadeDto>> Handle(GetLocalidadesByMunicipioQuery request, CancellationToken cancellationToken)
    {
        try
        {
            List<LocalidadeDto> result;
            if (_user.Perfil == UserRoles.Administrador)
            {
                result = await _context.Localidades
                    .Where(x => x.Municipio!.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Nome)
                    .ToListAsync(cancellationToken);
            }
            else
            {
                result = await _context.Localidades
                    .Where(x => x.Municipio!.Id == request.Id && x.Status)
                    .AsNoTracking()
                    .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Nome)
                    .ToListAsync(cancellationToken);
            }

            return result;
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            throw;
        }
    }
}
