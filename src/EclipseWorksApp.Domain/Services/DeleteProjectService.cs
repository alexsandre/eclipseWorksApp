using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Domain.Exceptions;
using EclipseWorksApp.Domain.Interfaces;

namespace EclipseWorksApp.Domain.Services;

public class DeleteProjectService
{
    private readonly IPortfolioManagement _portfolioManagement;
    public DeleteProjectService(IPortfolioManagement portfolioManagement)
    {
        _portfolioManagement = portfolioManagement;
    }

    public async System.Threading.Tasks.Task RunAsync(int idUser, int idProject)
    {   
        var project = await GetProject(idProject, idUser);
        if (project is null)
            throw new DomainException(Strings.ProjectNotFound);

        if (await projectHasOpenTasks(idProject))
            throw new DomainException(Strings.DeleteProjectFailed);

        project.Disable();
        await _portfolioManagement.SaveAsync();
    }

    private async Task<bool> projectHasOpenTasks(int idProject)
    {
        var tasks = await _portfolioManagement.GetTaksByProject(idProject);

        return tasks.Any(t => t.Status != Status.Finished);
    }

    private async Task<Project?> GetProject(int idProject, int idUser) => await _portfolioManagement.GetProjectByUser(idProject, idUser);
}
