using MediatR;

namespace EclipseWorksApp.API.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<CreateTaskResponse>
    {
        public int IdUserLogged { get; set; }
        public int IdProject { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int Status { get; set; }

    }
}
