namespace EclipseWorksApp.API.Application.Queries.GetAllTasksByProject
{
    public interface IGetAllTasksByProjectQuery
    {
        Task<IEnumerable<GetAllTasksByProjectModel>> RunAsync(int idUser, int idProject);
    }
}
