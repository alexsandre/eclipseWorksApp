using EclipseWorksApp.API.Application.Queries.GetAllProjects;
using EclipseWorksApp.API.Application.Queries.GetAllTasksByProject;
using EclipseWorksApp.API.Application.Queries.GetReportPerformance;
using EclipseWorksApp.Domain.Interfaces;
using EclipseWorksApp.Domain.Services;
using EclipseWorksApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EclipseWorksApp.API.Config;

public static class CustomInjection
{
    public static void AddCustomInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Queries
        services.AddScoped<IGetAllProjectsQuery, GetAllProjectsQuery>();
        services.AddScoped<IGetAllTasksByProjectQuery, GetAllTasksByProjectQuery>();
        services.AddScoped<IGetReportPerformanceQuery, GetReportPerformanceQuery>();

        // Add Mediatr Commands
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Add EF core DBContexts
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<EclipseWorksAppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DbContext")));

        services.AddScoped<IPortfolioManagement, EclipseWorksAppDbContext>();
        
        services.AddScoped<DeleteProjectService, DeleteProjectService>();
    }
}
