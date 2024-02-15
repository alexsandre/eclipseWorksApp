using EclipseWorksApp.API.Application.Commands.AddCommentToTask;
using EclipseWorksApp.API.Application.Commands.CreateTask;
using EclipseWorksApp.API.Application.Commands.DeleteTask;
using EclipseWorksApp.API.Application.Commands.UpdateTask;
using EclipseWorksApp.API.Application.Queries.GetAllTasksByProject;
using EclipseWorksApp.API.Models;
using EclipseWorksApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EclipseWorksApp.API.Controllers
{
    [ApiController]
    [Route("api/projects/{idProject}/[controller]")]
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> Get([FromHeader(Name = "User-Logged")] int idUserLogged,
                                       int idProject,
                                       IGetAllTasksByProjectQuery query)
        {
            var data = await query.RunAsync(idUserLogged, idProject);

            return Results.Ok(new CustomHttpResponse(data));
        }

        [HttpPost]
        public async Task<IResult> Post([FromHeader(Name = "User-Logged")] int idUserLogged,
                                        int idProject,
                                        [FromBody] CreateTaskCommand command,
                                        IMediator mediator)
        {
            command.IdUserLogged = idUserLogged;
            command.IdProject = idProject;
            var data = await mediator.Send(command);

            return Results.Ok(new CustomHttpResponse(data));
        }

        [HttpPost]
        [Route("/{idTask}/Comments")]
        public async Task<IResult> PostComment([FromHeader(Name = "User-Logged")] int idUserLogged,
                                        int idProject,
                                        int idTask,
                                        AddCommentToTaskCommand command,
                                        IMediator mediator)
        {
            command.IdUserLogged = idUserLogged;
            command.IdProject = idProject;
            command.IdTask = idTask;
            var data = await mediator.Send(command);

            return Results.Ok(new CustomHttpResponse(data));
        }

        [HttpPatch]
        public async Task<IResult> Patch([FromHeader(Name = "User-Logged")] int idUserLogged,
                                         int idProject,
                                         int idTask,
                                         [FromBody] UpdateTaskCommand command,
                                         IMediator mediator)
        {
            command.IdUserLogged = idUserLogged;
            command.IdProject = idProject;
            command.IdTask = idTask;

            var data = await mediator.Send(command);

            return Results.Ok(new CustomHttpResponse(data));
        }

        [HttpDelete]
        [Route("/{idTask}")]
        public async Task<IResult> Delete([FromHeader(Name = "User-Logged")] int idUserLogged,
                                          int idProject,
                                          int idTask,
                                          IMediator mediator)
        {
            var command = new DeleteTaskCommand() { IdUserLogged = idUserLogged, IdProject = idProject, IdTask = idTask };
            
            await mediator.Send(command);

            return Results.Ok();    
        }
    }
}
