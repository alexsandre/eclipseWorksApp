namespace EclipseWorksApp.API.Queries.GetReportPerformance;

public interface IGetReportPerformanceQuery
{
    Task<GetReportPerformanceModel> RunAsync(int idUser);
}
