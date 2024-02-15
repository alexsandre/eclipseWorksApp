

namespace EclipseWorksApp.API.Queries.GetAllTasksByProject
{
    public class GetAllTasksByProjectQuery : IGetAllTasksByProjectQuery
    {
        public Task<IEnumerable<GetAllTasksByProjectModel>> RunAsync(int idProject)
        {
            throw new NotImplementedException();
        }
    }
}
