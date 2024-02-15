using MediatR;

namespace EclipseWorksApp.API.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<CreateProjectResponse>
    {
        public int IdUserLogged { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
