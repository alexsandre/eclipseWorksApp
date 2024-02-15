namespace EclipseWorksApp.API.Application.Commands.CreateProject
{
    public class CreateProjectResponse
    {
        public CreateProjectResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
