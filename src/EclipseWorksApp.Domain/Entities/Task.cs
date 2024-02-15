namespace EclipseWorksApp.Domain.Entities;

public class Task : EntityBase
{
    public Task(
        string title,
        string description,
        DateTime dueDate,
        Status status)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Comments = new HashSet<Comment>();
    }

    public string Title { get; internal set; }
    public string Description { get; internal set; }
    public DateTime DueDate { get; internal set; }
    public Status Status { get; internal set; }

    public ICollection<Comment> Comments { get; internal set; }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
}
