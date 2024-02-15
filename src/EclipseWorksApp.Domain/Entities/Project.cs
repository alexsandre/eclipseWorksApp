namespace EclipseWorksApp.Domain.Entities;

public class Project : EntityBase
{
    public Project(
        string name,
        string description,
        User user,
        ICollection<Task> tasks)
    {
        Name = name;
        Description = description;
        User = user;
        Tasks = tasks;
    }

    public string Name { get; }
    public string Description { get; }
    public User User { get; }
    public ICollection<Task> Tasks { get; }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }
}
