using EclipseWorksApp.API.Application.Commands.CreateTask;
using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.API.Application.Commands.UpdateTask;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
{
    private readonly EclipseWorksAppDbContext _dbContext;
    public UpdateTaskHandler(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
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

        task.SetTitle(request.Title, userLogged)
            .SetDescription(request.Description, userLogged)
            .SetDueDate(request.DueDate, userLogged)
            .SetStatus(request.Status, userLogged);
        await _dbContext.SaveChangesAsync();

        return new UpdateTaskResponse(task.Id,
                                      task.Title,
                                      task.Description,
                                      task.DueDate,
                                      (int)task.Status,
                                      task.Project.Id,
                                      task.Project.Name);
    }

    public Task<User?> GetUserLogged(int id) =>
        _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == id);

    public Task<Project?> GetProject(int idProject, int idUser) =>
        _dbContext.Table<Project>().FirstOrDefaultAsync(p => p.Id == idProject && p.IdUser == idUser);

    public Task<Entities.Task?> GetTask(int id) =>
        _dbContext.Table<Entities.Task>().FirstOrDefaultAsync(t => t.Id == id);
}
