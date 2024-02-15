using EclipseWorksApp.Domain.Entities;
using EclipseWorksApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace EclipseWorksApp.Infra.DBContext;

public class EclipseWorksAppDbContext : DbContext, IPortfolioManagement
{
    public EclipseWorksAppDbContext(DbContextOptions<EclipseWorksAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public IQueryable<TEntity> Table<TEntity>() where TEntity : EntityBase => Set<TEntity>();

    public async Task<Project?> GetProjectByUser(int id, int idUser)
    {
        return await Set<Project>().FirstOrDefaultAsync(p => p.Id == id && p.IdUser == idUser);
    }

    public async Task<List<Domain.Entities.Task>> GetTaksByProject(int idProject)
    {
        return await Set<Domain.Entities.Task>().Where(t => t.IdProject == idProject).ToListAsync();
    }

    public async System.Threading.Tasks.Task DeleteProject(Project project)
    {
        Remove(project);
        await SaveChangesAsync();
    }
}
