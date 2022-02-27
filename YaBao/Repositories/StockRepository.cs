using Microsoft.EntityFrameworkCore;
using YaBao.Data;
using YaBao.Models;

namespace YaBao.Repositories
{
    /// <summary>
    /// Repository for working with Stock model in database
    /// </summary>
    public class StockRepository : EFGenericRepository<Stock>
    {
        private readonly ApplicationContext _context;
        /// <summary>
        /// Base constructor for repository
        /// </summary>
        /// <param name="context"></param>
        public StockRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        ///<inheritdoc/>
        public async override Task<IEnumerable<Stock>> GetAsync()
        {
            var allStocks = await _context.Stocks.Include(x => x.Products).ToListAsync();
            return allStocks.Skip(Math.Max(0, allStocks.Count() - 5));

        }
        ///<inheritdoc/>
        public async override Task CreateAsync(Stock stock)
        {
            stock.Products = new List<Product>();
            foreach (var id in stock.ProductsIds)
            {
                Product product = await _context.Products.FirstAsync(x => x.Id == id);
                stock.Products.Add(product);
            }
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

    }
}
