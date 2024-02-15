using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.API.Application.Commands.AddCommentToTask;

public class AddCommentToTaskHandler : IRequestHandler<AddCommentToTaskCommand, AddCommentToTaskModel>
{
    private readonly EclipseWorksAppDbContext _dbContext;

    public AddCommentToTaskHandler(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AddCommentToTaskModel> Handle(AddCommentToTaskCommand request, CancellationToken cancellationToken)
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

        var comment = new Comment(DateTime.UtcNow, request.Text, userLogged, task);
        task.AddComment(comment, userLogged);
        await _dbContext.SaveChangesAsync();

        return new AddCommentToTaskModel(comment.Id,
                                         comment.Date,
                                         comment.Text,
                                         comment.User.Name);
    }

    public Task<User?> GetUserLogged(int id) =>
        _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == id);

    public Task<Project?> GetProject(int idProject, int idUser) =>
        _dbContext.Table<Project>().FirstOrDefaultAsync(p => p.Id == idProject && p.IdUser == idUser);

    public Task<Entities.Task?> GetTask(int id) =>
        _dbContext
        .Table<Entities.Task>()
        .Include(t => t.Comments)
        .FirstOrDefaultAsync(t => t.Id == id);
}
