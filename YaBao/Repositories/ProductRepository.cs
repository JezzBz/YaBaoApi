using Microsoft.EntityFrameworkCore;
using YaBao.Data;
using YaBao.Models;

namespace YaBao.Repositories
{
    /// <summary>
    /// Repository  for working with Product model
    /// </summary>
    public class ProductRepository : EFGenericRepository<Product>
    {

         ApplicationContext _context;
        ///<inheritdoc/>
        public ProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        ///<inheritdoc/>
        public async override Task CreateAsync(Product product)
        {
            if (product.IsNew & _context.Products.Count(x => x.IsNew) >= 4)
            {

                _context.Products.First(x => x.IsNew).IsNew = false;
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Selection of novtiles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetNewAsync() => await _context.Products.Where(x => x.IsNew).ToListAsync();
    }
}
