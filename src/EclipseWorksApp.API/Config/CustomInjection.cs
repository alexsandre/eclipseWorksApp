﻿using EclipseWorksApp.API.Application.Queries.GetAllProjects;
using EclipseWorksApp.API.Application.Queries.GetAllTasksByProject;
using EclipseWorksApp.API.Application.Queries.GetReportPerformance;
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

    }
}
