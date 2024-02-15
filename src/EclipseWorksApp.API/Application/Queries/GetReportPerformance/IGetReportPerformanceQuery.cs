namespace EclipseWorksApp.API.Application.Queries.GetReportPerformance;

public interface IGetReportPerformanceQuery
{
    Task<IEnumerable<GetReportPerformanceModel>> RunAsync(int idUserLogged);
}
