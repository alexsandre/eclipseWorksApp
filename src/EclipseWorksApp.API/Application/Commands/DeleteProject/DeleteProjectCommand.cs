using MediatR;

namespace EclipseWorksApp.API.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int IdUserLogged { get; set; }
        public int IdProject { get; set; }
    }
}
