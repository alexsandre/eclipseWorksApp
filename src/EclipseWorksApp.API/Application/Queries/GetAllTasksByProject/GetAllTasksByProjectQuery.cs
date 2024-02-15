using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using pTask = EclipseWorksApp.Domain.Entities.Task;

namespace EclipseWorksApp.API.Application.Queries.GetAllTasksByProject;

public class GetAllTasksByProjectQuery : IGetAllTasksByProjectQuery
{
    private readonly EclipseWorksAppDbContext _dbContext;
    public GetAllTasksByProjectQuery(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetAllTasksByProjectModel>> RunAsync(int idUser, int idProject)
    {
        var user = await GetUser(idUser);
        if (user is null)
            throw new UnauthorizedAccessException();

        var tasks = await _dbContext.Table<pTask>()
            .Where(t => t.IdProject == idProject && t.Project.IdUser == idUser)
            .AsNoTracking()
            .ToListAsync();

        return tasks
            .Select(t => new GetAllTasksByProjectModel(t.Id,
                                                       t.Title,
                                                       t.Description,
                                                       t.DueDate,
                                                       (int)t.Status));
    }

    private Task<User?> GetUser(int idUser) => _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == idUser);
}
