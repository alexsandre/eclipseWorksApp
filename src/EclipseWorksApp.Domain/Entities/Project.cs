using EclipseWorksApp.Domain.Consts;

namespace EclipseWorksApp.Domain.Entities;

public class Project : EntityBase
{
    private Project() { }
    public Project(
        string name,
        string description,
        User user)
    {
        Name = name;
        Description = description;
        User = user;
        Active = true;
    }

    public string Name { get; }
    public string Description { get; }
    public bool Active { get; set; }

    public int IdUser { get; private set; }
    public User User { get; }

    public ICollection<Task> Tasks { get; }

    public void AddTask(Task task)
    {
        if (Tasks.Count >= 20)
            throw new InvalidOperationException(Strings.NumberOfTasksExceeded);

        Tasks.Add(task);
    }

    public void Disable() => Active = false;
}
