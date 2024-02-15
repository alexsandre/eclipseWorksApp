namespace EclipseWorksApp.Domain.Entities;

public class Comment : EntityBase
{
    public Comment(
        DateTime date,
        User user,
        string text)
    {
        Date = date;
        User = user;
        Text = text;
    }

    public DateTime Date { get; }
    public User User { get; }
    public string Text { get; }
}
