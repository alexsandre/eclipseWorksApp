using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.API.Application.Commands.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
{
    private readonly EclipseWorksAppDbContext _dbContext;
    public CreateTaskHandler(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var userLogged = await GetUserLogged(request.IdUserLogged);
        if (userLogged is null)
            throw new UnauthorizedException();

        var project = await GetProject(request.IdProject, request.IdUserLogged);
        if (project is null)
            throw new NotFoundException(Strings.ProjectNotFound);

        var task = new Entities.Task(request.Title, request.Description, request.DueDate, (Status)request.Status, (Priority)request.Priority, project);
        project.AddTask(task);

        await _dbContext.SaveChangesAsync();

        return new CreateTaskResponse(task.Id,
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
        _dbContext.Table<Project>().Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == idProject && p.IdUser == idUser);
}
