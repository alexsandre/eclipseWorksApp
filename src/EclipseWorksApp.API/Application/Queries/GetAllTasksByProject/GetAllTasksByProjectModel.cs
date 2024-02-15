namespace EclipseWorksApp.API.Application.Queries.GetAllTasksByProject
{
    public class GetAllTasksByProjectModel(int id, string title, string description, DateTime dueDate, int status)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public DateTime DueDate { get; set; } = dueDate;
        public int Status { get; set; } = status;
    }
}