namespace EclipseWorksApp.Domain.Entities;

public class Task : EntityBase
{
    private Task() { }
    public Task(
        string title,
        string description,
        DateTime dueDate,
        Status status,
        Priority priority,
        Project project)
    {
        _title = title;
        _description = description;
        _dueDate = dueDate;
        _status = status;
        Priority = priority;
        Project = project;
    }

    private string _title;
    public string Title
    {
        get {   return _title; }
    }
    public Task SetTitle(string value, User user)
    {
        if (string.IsNullOrEmpty(value) || value == _title)
            return this;

        registerLog(DateTime.UtcNow, "Title", _title, value, user.Name);
        _title = value;
        return this;
    }

    private string _description;
    public string Description { get { return _description; } }
    public Task SetDescription(string value, User user)
    {
        if (string.IsNullOrEmpty(value) || value == _description)
            return this;

        registerLog(DateTime.UtcNow, "Description", _description, value, user.Name);
        _description= value;
        return this;
    }

    private DateTime _dueDate;
    public DateTime DueDate { get { return _dueDate; } }
    public Task SetDueDate(DateTime? value, User user)
    {
        if (value is  null || value == _dueDate)
            return this;

        registerLog(DateTime.UtcNow, "Due Date", string.Format("{0:u}", _dueDate), string.Format("{0:u}", value.Value), user.Name);
        _dueDate = value.Value;
        return this;
    }

    private Status _status;
    public Status Status { get { return _status; } }
    public Task SetStatus(Status? value, User user)
    {
        if (value is null || value == _status)
            return this;

        registerLog(DateTime.UtcNow, "Status", _status.ToString("D"), value.Value.ToString("D"), user.Name);
        _status = value.Value;
        return this;
    }

    public Priority Priority { get; }

    public int IdProject { get; protected set; }
    public Project Project { get; }

    public ICollection<Log> Logs { get; private set; } = new HashSet<Log>();
    public ICollection<Comment> Comments { get; private set; } = new HashSet<Comment>();

    public void AddComment(Comment comment, User user)
    {
        Comments.Add(comment);
        registerLog(DateTime.UtcNow, "Comments", string.Empty, comment.Text, user.Name);
    }

    private void registerLog(DateTime date, string field, string oldValue, string newValue, string nameUser)
    {
        var log = new Log(date, field, oldValue, newValue, nameUser, this);
        Logs.Add(log);
    }
}
