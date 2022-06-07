using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public BaseRepository(TravelAgencyContext _travelAgency)
        {
            this._travelAgency = _travelAgency;
        }

        protected readonly TravelAgencyContext _travelAgency;
        private DbSet<TEntity> _entities;
        protected DbSet<TEntity> Entities => this._entities ??= _travelAgency.Set<TEntity>();

        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat)
            => await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() => await this.Entities.ToListAsync().ConfigureAwait(false);

        public virtual async Task<OperationDetail> CreateAsync(TEntity entity)
        {
            try
            {
                await this.Entities.AddAsync(entity).ConfigureAwait(false);
                await this._travelAgency.SaveChangesAsync();
                return new OperationDetail() { Text = "Created", IsCompleted = true};
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Not Created");
                return new OperationDetail() { Text = "Not Created", IsCompleted = false };
            }
        }
    }
}
