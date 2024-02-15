using EclipseWorksApp.Domain.Entities;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.Domain.Interfaces;

public interface IPortfolioManagement
{
    Task<Project?> GetProjectByUser(int id, int idUser);
    Task<List<Entities.Task>> GetTaksByProject(int idProject);
    System.Threading.Tasks.Task SaveAsync();
}
