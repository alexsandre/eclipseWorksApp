namespace EclipseWorksApp.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = 0;
    }

    public virtual int Id { get; internal set; }
}
