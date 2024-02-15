using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksApp.Infra.Mapping;

public abstract class EntityBaseConfigMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
{
    private readonly string _tableName;
    private readonly string _columnId;

    protected EntityBaseConfigMap(string tableName, string columnId)
    {
        _tableName = tableName;
        _columnId = columnId;
    }

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(_tableName);

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Id).HasColumnName(_columnId);
    }
}
