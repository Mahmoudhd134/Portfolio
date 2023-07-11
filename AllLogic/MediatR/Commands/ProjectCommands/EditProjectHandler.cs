using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AllLogic.MediatR.Commands.ProjectCommands;

public record EditProjectCommand(int Id,EditProjectDto EditProjectDto) : IRequest<Response<bool>>;

public class EditProjectHandler : IRequestHandler<EditProjectCommand, Response<bool>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public EditProjectHandler(IdentityContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
    {
        var (id, editProjectDto) = request;
        if(id != editProjectDto.Id)
            return Response<bool>.Failure(ProjectErrors.NotMatchedId);

        var project = _mapper.Map<Project>(editProjectDto);
        _context.Projects.Update(project);
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}