using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Domain.Services;
using EclipseWorksApp.Infra.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.API.Application.Commands.DeleteTask;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly EclipseWorksAppDbContext _dbContext;

    public DeleteTaskHandler(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var userLogged = await GetUserLogged(request.IdUserLogged);
        if (userLogged is null)
            throw new UnauthorizedException();

        var project = await GetProject(request.IdProject, request.IdUserLogged);
        if (project is null)
            throw new NotFoundException(Strings.ProjectNotFound);

        var task = await GetTask(request.IdTask);
        if (task is null)
            throw new NotFoundException(Strings.TaskNotFound);

        _dbContext.Remove(task);
        await _dbContext.SaveChangesAsync();
    }

    public Task<User?> GetUserLogged(int id) =>
        _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == id);

    public Task<Project?> GetProject(int idProject, int idUser) =>
        _dbContext.Table<Project>().FirstOrDefaultAsync(p => p.Id == idProject && p.IdUser == idUser);

    public Task<Entities.Task?> GetTask(int id) =>
        _dbContext.Table<Entities.Task>()
        .Include(t => t.Logs)
        .Include(t => t.Comments)
        .FirstOrDefaultAsync(t => t.Id == id);
}
