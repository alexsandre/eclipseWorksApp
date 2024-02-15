namespace EclipseWorksApp.API.Application.Queries.GetReportPerformance
{
    public class GetReportPerformanceModel(string name, int count)
    {
        public string NameUser { get; set; } = name;
        public int NumberTasksCompleted { get; set; } = count;
    }
}