using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EclipseWorksApp.Infra.DBContext;

public class EclipseWorksAppDbContext : DbContext
{
    public EclipseWorksAppDbContext(DbContextOptions<EclipseWorksAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public IQueryable<TEntity> Table<TEntity>() where TEntity : EntityBase => Set<TEntity>();
}
