using MediatR;

namespace EclipseWorksApp.API.Application.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<object>
    {
        public int IdUserLogged { get; set; }
        public int IdProject { get; set; }
        public int IdTask { get; set; }
    }
}
