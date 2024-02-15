using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksApp.Infra.Mapping;

internal class UserConfigMap : EntityBaseConfigMap<User>
{
    public UserConfigMap() : base("Users", "Id") { }

    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Name);
        builder.Property(u => u.Profile)
            .HasConversion<int>();

        builder
            .HasMany(u => u.Projects)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.IdUser)
            .HasPrincipalKey(u => u.Id);

        builder
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.IdUser)
            .HasPrincipalKey(u => u.Id);
    }
}
