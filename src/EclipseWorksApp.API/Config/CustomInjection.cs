using EclipseWorksApp.API.Queries.GetAllProjects;
using EclipseWorksApp.API.Queries.GetAllTasksByProject;
using EclipseWorksApp.API.Queries.GetReportPerformance;
using System.Reflection;

namespace EclipseWorksApp.API.Config;

public static class CustomInjection
{
    public static void AddCustomInjection(this IServiceCollection services)
    {
        services.AddScoped<IGetAllProjectsQuery, GetAllProjectsQuery>();
        services.AddScoped<IGetAllTasksByProjectQuery, GetAllTasksByProjectQuery>();
        services.AddScoped<IGetReportPerformanceQuery, GetReportPerformanceQuery>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
