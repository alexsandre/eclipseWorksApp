namespace EclipseWorksApp.Domain.Entities;

public class Log : EntityBase
{
    private Log() { }
    public Log(
        DateTime date,
        string field,
        string oldValue,
        string newValue,
        string nameUser,
        Task task)
    {
        Date = date;
        Field = field;
        OldValue = oldValue;
        NewValue = newValue;
        NameUser = nameUser;

        Task = task;
    }

    public DateTime Date { get; set; }
    public string Field { get; private set; }
    public string OldValue { get; private set; }
    public string NewValue { get; private set; }
    public string NameUser { get; private set; }

    public int IdTask { get; private set; }
    public Task Task { get; private set; }
}
