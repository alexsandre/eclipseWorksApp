namespace EclipseWorksApp.API.Commands.CreateProject
{
    public class CreateProjectResponse
    {
        public CreateProjectResponse(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
