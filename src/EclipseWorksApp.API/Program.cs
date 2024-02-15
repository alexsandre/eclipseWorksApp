using EclipseWorksApp.API.Application.Commands.CreateProject;
using EclipseWorksApp.API.Application.Commands.CreateTask;
using EclipseWorksApp.API.Application.Commands.DeleteProject;
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

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
