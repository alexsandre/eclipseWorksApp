using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksApp.Infra.Mapping;

internal class CommentConfigMap : EntityBaseConfigMap<Comment>
{
    public CommentConfigMap() : base("Comments", "Id") { }

    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Date);
        builder.Property(c => c.Text);
    }
}
