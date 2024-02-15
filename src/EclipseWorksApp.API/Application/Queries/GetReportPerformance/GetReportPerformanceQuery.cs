using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using pTask = EclipseWorksApp.Domain.Entities.Task;
using EclipseWorksApp.API.Exceptions;

namespace EclipseWorksApp.API.Application.Queries.GetReportPerformance;

public class GetReportPerformanceQuery : IGetReportPerformanceQuery
{
    private readonly EclipseWorksAppDbContext _dbContext;
    public GetReportPerformanceQuery(EclipseWorksAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetReportPerformanceModel>> RunAsync(int idUserLogged)
    {
        var user = await GetUser(idUserLogged);
        if (user is null || !user.Profile.Equals(Profile.Manager))
            throw new UnauthorizedException();

        var dateStart = DateTime.UtcNow.AddDays(-30);
        var nameField = "Status";
        var valueFinished = (int)Status.Finished;

        var dataReport = await _dbContext
            .Table<Log>()
            .Where(t => t.Field == nameField && t.NewValue == valueFinished.ToString())
            .AsNoTracking()
            .GroupBy(t => t.NameUser)
            .ToListAsync();

        return dataReport
            .Select(d => new GetReportPerformanceModel(d.Key, d.Count()));
    }

    private Task<User?> GetUser(int idUser) => _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == idUser);
}
