namespace EclipseWorksApp.API.Queries.GetAllTasksByProject
{
    public interface IGetAllTasksByProjectQuery
    {
        Task<IEnumerable<GetAllTasksByProjectModel>> RunAsync(int idProject);
    }
}
