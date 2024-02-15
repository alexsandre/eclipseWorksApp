using EclipseWorksApp.API.Commands.CreateProject;
using EclipseWorksApp.API.Config;
using EclipseWorksApp.API.Queries.GetAllProjects;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("v1/projects", (IGetAllProjectsQuery query) =>
{
    return Results.Ok();
})
.WithName("GetProjects")
.WithOpenApi();

app.MapPost("v1/projects", ([FromBody]CreateProjectCommand command, IMediator mediator) =>
{
    return Results.Ok();
})
.WithName("PostProject")
.WithOpenApi();

app.MapGet("v1/projects/{idProject}/tasks", (int idProject) =>
{
    return Results.Ok();
})
.WithName("GetTasksByProject")
.WithOpenApi();

app.MapPost("v1/projects/{idProject}/tasks", (int idProject) =>
{
    return Results.Ok();
})
.WithName("PostTask")
.WithOpenApi();

app.MapPatch("v1/projects/{idProject}/tasks/{idTask}", (int idProject, int idTask) =>
{
    return Results.Ok();
})
.WithName("PatchTask")
.WithOpenApi();

app.MapDelete("v1/projects/{idProject}/tasks/{idTask}", (int idProject, int idTask) =>
{
    return Results.Ok();
})
.WithName("DeleteTask")
.WithOpenApi();

app.MapPost("v1/projects/{idProject}/tasks/{idTask}/comments", (int idProject, int idTask) =>
{
    return Results.Ok();
})
.WithName("PostCommentInTask")
.WithOpenApi();

app.MapGet("v1/reports/performance", () =>
{
    return Results.Ok();
})
.WithName("GetReportPerformance")
.WithOpenApi();

app.Run();
