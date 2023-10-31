using Microsoft.EntityFrameworkCore;
using PlayerStats.DAL.Repositories.Interfaces;

namespace PlayerStats.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly PlayerStatsContext databaseContext;
        protected readonly DbSet<TEntity> table;

        public GenericRepository(PlayerStatsContext databaseContext)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await table.FindAsync(id);

        public virtual async Task InsertAsync(TEntity entity) => await table.AddAsync(entity);

        public virtual async Task UpdateAsync(TEntity entity) => await Task.Run(() => table.Update(entity));

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }
    }
}
