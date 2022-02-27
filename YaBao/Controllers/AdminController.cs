using Microsoft.AspNetCore.Mvc;
using YaBao.Data;
using YaBao.Models;
using YaBao.Repositories;

namespace YaBao.Controllers
{
    /// <summary>
    /// Controller for admin page
    /// </summary>

    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor for AdminController
        /// </summary>
        /// <param name="dataContext">DataContext</param>
        public AdminController(ApplicationContext dataContext)
        {
            _context = dataContext;
        }

        //Не забыть добавить загрузку файла 
        /// <summary>
        /// Http Post  method that adds a new product to the database
        /// </summary>
        /// <param name="product">Json model of type Product</param>
        /// <returns>Http response</returns>
        /// <remarks>url/addProduct</remarks>
        [HttpPost, DisableRequestSizeLimit]
        [Route("product")]
        public async Task<IActionResult> AddProductAsync([FromForm] Product product)
        {
            ProductRepository repository = new ProductRepository(_context);
            try
            {
                await repository.CreateAsync(product);
            }
            catch
            {
                return StatusCode(422);

            }

            return StatusCode(201);
        }

        /// <summary>
        /// Http Post method that adds new Product Type to the database
        /// </summary>
        /// <param name="type">Json model of type ProductType</param>
        /// <returns>Status code 200 if item added or status code 418 otherwise</returns>
        /// <remarks>url/deleteProduct</remarks>
        [HttpPost]
        [Route("type")]
        public async Task<IActionResult> AddProductTypeAsync([FromForm] ProductType type)
        {
            EFGenericRepository<ProductType> repository = new EFGenericRepository<ProductType>(_context);
            try
            {
                await repository.CreateAsync(type);
            }
            catch
            {
                return StatusCode(418);

            }
            return Ok();
        }

        /// <summary>
        /// Adding stock to the database
        /// </summary>
        /// <param name="stock">Stock json-object</param>
        /// <returns>Success result</returns>
        [HttpPost]
        [Route("stock")]
        public async Task<IActionResult> AddStockAsync(Stock stock)
        {
            StockRepository repository = new StockRepository(_context);
            try
            {
                await repository.CreateAsync(stock);
            }
            catch
            {
                return StatusCode(422);
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Adding slide to the dataase
        /// </summary>
        /// <param name="slide">Json-onject slide</param>
        /// <returns></returns>
        [HttpPost]
        [Route("slide")]
        public async Task<IActionResult> AddSlideAsync(Slide slide)
        {
            SlideRepository repository = new SlideRepository(_context);
            try
            {
                await repository.CreateAsync(slide);
            }
            catch
            {

                return StatusCode(422);
            }
            return StatusCode(201);
        }

        /// <summary>
        /// Http Delete metod that removes product from database
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Status code 200 if item added or status code 400 otherwise</returns>
        [HttpDelete]
        [Route("product")]
        public async Task<IActionResult> RemoveProductAsync(int id)
        {
            ProductRepository repository = new ProductRepository(_context);
            try
            {
                await repository.RemoveAsync(await repository.FindByIdAsync(id));
            }
            catch
            {
                return StatusCode(404);
            }
            return StatusCode(204);
        }
        /// <summary>
        /// Method to remove ProductTypes from database
        /// </summary>
        /// <param name="id">list of int ids</param>
        [HttpDelete]
        [Route("type")]
        public async Task<IActionResult> RemoveProductTypeAsync(int id)
        {
            EFGenericRepository<ProductType> repository = new EFGenericRepository<ProductType>(_context);
            try
            {
                await repository.RemoveAsync(await repository.FindByIdAsync(id));
            }
            catch
            {
                return StatusCode(422);
            }
            return StatusCode(204);


        }
       
        /// <summary>
        /// Method to remove Stocks from database
        /// </summary>
        /// <param name="id">List of StockIds</param>
        [HttpDelete]
        [Route("stock")]
        public async Task<IActionResult> RemoveStockAsync(int id)
        {
            StockRepository repository = new StockRepository(_context);
            try
            {
                await repository.RemoveAsync(await repository.FindByIdAsync(id));
            }
            catch
            {

                return StatusCode(422);
            }

            return StatusCode(204);
        }


        /// <summary>
        /// Update stock object in the DataBase
        /// </summary>
        /// <param name="stock">Json-object stock</param>
        /// <returns></returns>
        [HttpPut]
        [Route("stock")]
        public async Task<IActionResult> UpdateStockAsync(Stock stock)
        {
            StockRepository repository = new StockRepository(_context);
            try
            {
                await repository.UpdateAsync(stock);
            }
            catch
            {

                return StatusCode(422);
            }
            return StatusCode(204);
        }

       

    }
}
