using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = EclipseWorksApp.Domain.Entities.Task;


namespace EclipseWorksApp.Infra.Mapping
{
    internal class TaskConfigMap : EntityBaseConfigMap<Task>
    {
        public TaskConfigMap() : base("Tasks", "Id") { }

        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Title).HasField("_title");
            builder.Property(t => t.Description).HasField("_description");
            builder.Property(t => t.DueDate).HasField("_dueDate");
            builder.Property(t => t.Status).HasConversion<int>().HasField("_status");

            builder
                .HasMany(t => t.Logs)
                .WithOne(l => l.Task)
                .HasForeignKey(l => l.IdTask)
                .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.Comments)
                .WithOne(c => c.Task)
                .HasForeignKey(c => c.IdTask)
                .HasPrincipalKey(t => t.Id);

        }
    }
}
