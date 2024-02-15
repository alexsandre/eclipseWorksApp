using EclipseWorksApp.Domain.Services;
using EclipseWorksApp.Infra.DBContext;
using MediatR;

namespace EclipseWorksApp.API.Application.Commands.DeleteTask;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, object>
{
    private readonly TaskDeleteService _taskDeleteService;
    private readonly EclipseWorksAppDbContext _dbContext;

    public DeleteTaskHandler(TaskDeleteService taskDeleteService)
    {
        _taskDeleteService = taskDeleteService;
    }

    public async Task<object> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        return null;
    }
}
