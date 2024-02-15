namespace EclipseWorksApp.API.Application.Queries.GetAllProjects
{
    public interface IGetAllProjectsQuery
    {
        Task<IEnumerable<GetAllProjectsModel>> RunAsync(int idUser);
    }
}
