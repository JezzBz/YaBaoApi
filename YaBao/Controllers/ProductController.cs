using Microsoft.AspNetCore.Mvc;
using YaBao.Data;
using YaBao.Models;
using YaBao.Repositories;

namespace YaBao.Controllers
{
    /// <summary>
    /// Main Api Controller
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _context;
        /// <summary>
        /// Base api controller 
        /// </summary>
        /// <param name="data"></param>
        public ProductController(ApplicationContext data)
        {
            _context = data;
        }
        /// <summary>
        /// Http Get method to select Types from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> GetTypesAsync()
        {
            EFGenericRepository<ProductType> repository = new EFGenericRepository<ProductType>(_context);
            try
            {
                return Ok(await repository.GetAsync());
            }
            catch
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Http Get method to select Stocks from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stocks")]
        public async Task<IActionResult> GetStocksAsync()
        {
            StockRepository repository = new StockRepository(_context);
            try
            {
                return Ok(await repository.GetAsync());
            }
            catch
            {

                return NotFound();
            }
        }
        /// <summary>
        /// Http Get method to select Novtiles from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("noveties")]
        public async Task<IActionResult> GetNovetiesAsync()
        {
            ProductRepository repository = new ProductRepository(_context);
            try
            {
                return Ok(await repository.GetNewAsync());
            }
            catch
            {

                return NotFound();
            }
        }
        /// <summary>
        /// Http Get method to select Products from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            ProductRepository repository = new ProductRepository(_context);
            try
            {
                return Ok(await repository.GetAsync());
            }
            catch
            {

                return NotFound();
            }
        }


    }
}