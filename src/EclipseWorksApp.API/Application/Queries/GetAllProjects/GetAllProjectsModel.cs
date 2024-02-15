namespace EclipseWorksApp.API.Application.Queries.GetAllProjects
{
    public class GetAllProjectsModel(int id, string name, string description, string owner)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Owner { get; set; } = owner;
    }
}