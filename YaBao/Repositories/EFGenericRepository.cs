using Microsoft.EntityFrameworkCore;
using YaBao.Data;
using YaBao.Interfaces;

namespace YaBao.Repositories
{
    /// <summary>
    /// Base class for reposytories
    /// </summary>
    /// <typeparam name="TEntity">Entity Type(DbSet)</typeparam>
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Application context
        /// </summary>
        protected readonly ApplicationContext _context;
        /// <summary>
        /// Entity DbSet Type from context
        /// </summary>
        protected readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Base contructor for repository
        /// </summary>
        /// <param name="context"> Applicatin EF context</param>
        public EFGenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// Method to select rows from database
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Method to find Entity in database
        /// </summary>
        /// <param name="id"> Entity id</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        /// <summary>
        /// Create row from Entity in database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Update Entity in database
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Remove Entity from database
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        public virtual async Task RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}

