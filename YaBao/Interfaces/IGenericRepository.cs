namespace YaBao.Interfaces
{
    /// <summary>
    /// Interface 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Method to Add entity to the database
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        Task CreateAsync(TEntity item);
        /// <summary>
        /// Method to find entity by id
        /// </summary>
        /// <param name="id">Entity primal key</param>
        /// <returns></returns>
        Task<TEntity> FindByIdAsync(int id);
        /// <summary>
        /// Method to Get Entitys from database 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync();
        /// <summary>
        /// Method to remove Entity from database
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        Task RemoveAsync(TEntity item);
        /// <summary>
        /// Method to Update Entity in the databse
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity item);
    }
}
