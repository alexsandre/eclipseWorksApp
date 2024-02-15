namespace EclipseWorksApp.Domain.Entities;

public class Comment : EntityBase
{
    private Comment() { }
    public Comment(DateTime date,
                   string text,
                   User user,
                   Task task)
    {
        Date = date;
        Text = text;
        User = user;
        Task = task;
    }

    public DateTime Date { get; }
    public string Text { get; }

    public int IdUser { get; private set; }
    public User User { get; private set; }

    public int IdTask { get; private set; }
    public Task Task { get; private set; }
}
