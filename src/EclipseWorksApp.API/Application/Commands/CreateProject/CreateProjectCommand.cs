using MediatR;

namespace EclipseWorksApp.API.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<CreateProjectResponse>
    {
        public int IdUserLogged { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
