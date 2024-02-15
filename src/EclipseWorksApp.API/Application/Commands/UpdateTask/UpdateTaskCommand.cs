using EclipseWorksApp.Domain.Entities;
using MediatR;

namespace EclipseWorksApp.API.Application.Commands.UpdateTask;

public class UpdateTaskCommand : IRequest<UpdateTaskResponse>
{
    public int IdUserLogged { get; set; }
    public int IdProject { get; set; }
    public int IdTask { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public Status? Status { get; set; }

}
