using MediatR;

namespace EclipseWorksApp.API.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
    {
        public Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
