namespace EclipseWorksApp.API.Application.Commands.CreateTask;

public class CreateTaskResponse
{
    public CreateTaskResponse(int id,
                              string title,
                              string description,
                              DateTime dueDate,
                              int status,
                              int idProject,
                              string nameProject)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        IdProject = idProject;
        NameProject = nameProject;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Status { get; set; }
    public int IdProject { get; set; }
    public string NameProject { get; set; }
}