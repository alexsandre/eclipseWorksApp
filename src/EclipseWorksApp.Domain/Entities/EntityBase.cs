namespace EclipseWorksApp.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = 0;
    }

    public virtual long Id { get; internal set; }
}
