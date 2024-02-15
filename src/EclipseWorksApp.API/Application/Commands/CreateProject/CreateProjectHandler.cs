using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Infra.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksApp.API.Application.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
    {
        private readonly EclipseWorksAppDbContext _dbContext;
        public CreateProjectHandler(EclipseWorksAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var userLogged = await GetUserLogged(request.IdUserLogged);
            if (userLogged is null)
                throw new UnauthorizedException();

            var project = new Project(request.Name,
                                      request.Description,
                                      userLogged);

            _dbContext.Add(project);
            await _dbContext.SaveChangesAsync();

            return new CreateProjectResponse(project.Id, project.Name, project.Description);
        }

        public Task<User?> GetUserLogged(int idUser) =>
            _dbContext.Table<User>().FirstOrDefaultAsync(u => u.Id == idUser);
    }
}
