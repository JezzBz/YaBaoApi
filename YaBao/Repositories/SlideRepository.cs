using Microsoft.EntityFrameworkCore;
using YaBao.Data;
using YaBao.Models;

namespace YaBao.Repositories
{
    /// <summary>
    /// Repository to work with Slide model in database
    /// </summary>
    public class SlideRepository : EFGenericRepository<Slide>
    {

        private readonly ApplicationContext _context;
        /// <summary>
        /// Base constructor for repository
        /// </summary>
        /// <param name="context"></param>
        public SlideRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        ///<inheritdoc/>
        public async override Task<IEnumerable<Slide>> GetAsync() => await _context.Slides.Include(x => x.Stock).ToArrayAsync();

    }

}
