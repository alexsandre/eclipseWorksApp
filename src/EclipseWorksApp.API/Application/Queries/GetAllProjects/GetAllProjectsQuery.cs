using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksApp.API.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IGetAllProjectsQuery
{
    private readonly EclipseWorksAppDbContext _dbContext;
    public GetAllProjectsQuery(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetAllProjectsModel>> RunAsync(int idUser)
    {
        var user = await GetUser(idUser);
        if (user is null)
            throw new UnauthorizedAccessException();

        var allProjects = await _dbContext
            .Table<Project>()
            .Where(p => p.IdUser == user.Id)
            .Include(p => p.User)
            .AsNoTracking()
            .ToListAsync();

        return allProjects
            .Select(p => new GetAllProjectsModel(p.Id, p.Name, p.Description, p.User.Name));
    }

    private Task<User?> GetUser(int idUser) => _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == idUser);
}
