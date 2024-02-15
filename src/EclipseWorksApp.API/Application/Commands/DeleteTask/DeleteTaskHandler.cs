using EclipseWorksApp.Domain.Services;
using EclipseWorksApp.Infra.DBContext;
using MediatR;

namespace EclipseWorksApp.API.Application.Commands.DeleteTask;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, object>
{
    private readonly EclipseWorksAppDbContext _dbContext;

    public async Task<object> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
