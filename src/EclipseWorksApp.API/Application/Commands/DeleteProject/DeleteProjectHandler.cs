using EclipseWorksApp.Domain.Services;
using EclipseWorksApp.Infra.DBContext;
using MediatR;

namespace EclipseWorksApp.API.Application.Commands.DeleteProject
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly DeleteProjectService _deleteProjectService;
        private readonly EclipseWorksAppDbContext _dbContext;

        public DeleteProjectHandler(
            DeleteProjectService deleteProjectService,
            EclipseWorksAppDbContext dbContext)
        {
            _deleteProjectService = deleteProjectService;
            _dbContext = dbContext;
        }

        async Task IRequestHandler<DeleteProjectCommand>.Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _deleteProjectService.RunAsync(request.IdUserLogged, request.IdProject);
        }
    }
}
