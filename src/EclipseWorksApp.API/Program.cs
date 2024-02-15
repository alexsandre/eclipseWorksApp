using EclipseWorksApp.API.Application.Commands.CreateProject;
using EclipseWorksApp.API.Application.Commands.CreateTask;
using EclipseWorksApp.API.Application.Commands.DeleteTask;
using EclipseWorksApp.API.Application.Commands.UpdateTask;
using EclipseWorksApp.API.Application.Queries.GetAllProjects;
using EclipseWorksApp.API.Application.Queries.GetAllTasksByProject;
using EclipseWorksApp.API.Application.Queries.GetReportPerformance;
using EclipseWorksApp.API.Config;
using EclipseWorksApp.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomInjection(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("v1/projects",
    async (HttpContext context, [FromHeader(Name = "User-Logged")] int idUserLogged,
           IGetAllProjectsQuery query) =>
{
    var data = await query.RunAsync(idUserLogged);
    
    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("GetProjects")
.WithOpenApi();

app.MapPost("v1/projects",
    async (HttpContext context, [FromHeader(Name = "User-Logged")] int idUserLogged,
           [FromBody]CreateProjectCommand command,
           IMediator mediator) =>
{
    command.IdUserLogged = idUserLogged;
    var data = await mediator.Send(command);
    
    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("PostProject")
.WithOpenApi();

app.MapGet("v1/projects/{idProject}/tasks",
    async (HttpContext context,
           [FromHeader(Name = "User-Logged")] int idUserLogged,
           int idProject,
           IGetAllTasksByProjectQuery query) =>
{
    var data = await query.RunAsync(idUserLogged, idProject);

    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("GetTasksByProject")
.WithOpenApi();

app.MapPost("v1/projects/{idProject}/tasks",
    async (HttpContext context,
           [FromHeader(Name = "User-Logged")] int idUserLogged,
           int idProject,
           [FromBody] CreateTaskCommand command,
           IMediator mediator) =>
{
    command.IdUserLogged = idUserLogged;
    command.IdProject = idProject;
    var data = await mediator.Send(command);

    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("PostTask")
.WithOpenApi();

app.MapPatch("v1/projects/{idProject}/tasks/{idTask}",
    async (HttpContext context,
           [FromHeader(Name = "User-Logged")] int idUserLogged,
           int idProject,
           int idTask,
           [FromBody]UpdateTaskCommand command,
           IMediator mediator) =>
{
    command.IdUserLogged = idUserLogged;
    command.IdProject = idProject;
    command.IdTask = idTask;

    var data = await mediator.Send(command);

    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("PatchTask")
.WithOpenApi();

app.MapDelete("v1/projects/{idProject}/tasks/{idTask}",
    async (HttpContext context, [FromHeader(Name = "User-Logged")] int idUserLogged,
           int idProject,
           int idTask,
           IMediator mediator) =>
{
    var command = new DeleteTaskCommand() { IdUserLogged = idUserLogged, IdProject = idProject, IdTask = idTask };
    var data = await mediator.Send(command);

    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("DeleteTask")
.WithOpenApi();

app.MapPost("v1/projects/{idProject}/tasks/{idTask}/comments",
    async (HttpContext context, [FromHeader(Name = "User-Logged")] int idUserLogged,
           int idProject,
           int idTask) =>
{
    return Results.Ok();
})
.WithName("PostCommentInTask")
.WithOpenApi();

app.MapGet("v1/reports/performance",
    async (HttpContext context, [FromHeader(Name = "User-Logged")] int idUserLogged,
           IGetReportPerformanceQuery query) =>
{
    var data = await query.RunAsync(idUserLogged);

    return Results.Ok(new CustomHttpResponse(data));
})
.WithName("GetReportPerformance")
.WithOpenApi();

app.Run();
