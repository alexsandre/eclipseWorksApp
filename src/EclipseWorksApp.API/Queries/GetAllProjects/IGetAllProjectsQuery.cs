namespace EclipseWorksApp.API.Queries.GetAllProjects
{
    public interface IGetAllProjectsQuery
    {
        Task<IEnumerable<GetAllProjectsModel>> RunAsync();
    }
}
