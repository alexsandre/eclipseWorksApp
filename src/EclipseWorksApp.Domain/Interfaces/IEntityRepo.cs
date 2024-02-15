using EclipseWorksApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorksApp.Domain.Interfaces
{
    public interface IEntityRepo
    {
        Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : EntityBase;
        Task<IQueryable<TEntity>> GetByIdAsync<TEntity>(int id) where TEntity : EntityBase;
    }
}
