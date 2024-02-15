using EclipseWorksApp.API.Application.Commands.CreateProject;
using EclipseWorksApp.API.Application.Commands.DeleteProject;
using EclipseWorksApp.API.Application.Queries.GetAllProjects;
using EclipseWorksApp.API.Models;
using EclipseWorksApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> Get([FromHeader(Name = "User-Logged")] int idUserLogged,
                                      IGetAllProjectsQuery query)
        {
            var data = await query.RunAsync(idUserLogged);

            return Results.Ok(new CustomHttpResponse(data));
        }
        
        [HttpPost]
        public async Task<IResult> Post([FromHeader(Name = "User-Logged")] int idUserLogged,
                                        [FromBody] CreateProjectCommand command,
                                        IMediator mediator)
        {
            command.IdUserLogged = idUserLogged;
            var data = await mediator.Send(command);
            return Results.Ok(new CustomHttpResponse(data));
        }

        [HttpDelete]
        public async Task<IResult> Delete([FromHeader(Name = "User-Logged")] int idUserLogged,
                                          int idProject,
                                          IMediator mediator)
        {
            var command = new DeleteProjectCommand() { IdUserLogged = idUserLogged, IdProject = idProject };
            await mediator.Send(command);

            return Results.Ok();
        }
    }
}
