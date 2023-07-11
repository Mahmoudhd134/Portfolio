using Microsoft.EntityFrameworkCore;

namespace AllLogic.MediatR.Commands.ProjectCommands;

public record DeleteProjectCommand(int Id) : IRequest<Response<bool>>;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Response<bool>>
{
    private readonly IdentityContext _context;

    public DeleteProjectHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<Response<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var project = await _context.Projects
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        
        if(project == null)
            return Response<bool>.Failure(ProjectErrors.WrongId(id));

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}