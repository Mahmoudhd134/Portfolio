using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AllLogic.MediatR.Queries.ProjectQueries;

public record GetProtectListQuery
    (int PageIndex, int PageSize, string NamePrefix) : IRequest<Response<ProjectListDto>>;

public class GetProtectListHandler : IRequestHandler<GetProtectListQuery, Response<ProjectListDto>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public GetProtectListHandler(IdentityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<ProjectListDto>> Handle(GetProtectListQuery request,
        CancellationToken cancellationToken)
    {
        var (pageIndex, pageSize, namePrefix) = request;
        var projects = _context.Projects
            .ProjectTo<ProjectForListDto>(_mapper.ConfigurationProvider);

        int allCount;
        if (string.IsNullOrWhiteSpace(namePrefix) == false)
        {
            projects = projects.Where(p => p.Name.ToLower().StartsWith(namePrefix.ToLower()));
            allCount = await _context.Projects
                .Where(p => p.Name.ToLower().StartsWith(namePrefix.ToLower()))
                .CountAsync(cancellationToken);
        }
        else
        {
            allCount = await _context.Projects
                .CountAsync(cancellationToken);
        }

        projects = projects
            .Skip(pageIndex * pageSize)
            .Take(pageSize);


        var projectsList = await projects.ToListAsync(cancellationToken);

        var hasNext = allCount > (pageIndex * pageSize + projectsList.Count);

        var list = new ProjectListDto()
        {
            Projects = projectsList,
            MaxPageIndex = allCount / pageSize - (allCount % pageSize == 0 ? 1 : 0),
            CurrentPageIndex = pageIndex,
            HasNext = hasNext
        };

        return list;
    }
}