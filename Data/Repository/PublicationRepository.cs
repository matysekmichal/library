using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class PublicationRepository : RepositoryBase<Publication>
    {
        public PublicationRepository(DataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Publication>> List()
        {
            return await DbSet
                .Include(p => p.Publisher)
                .Include(p => p.Author)
                .Include(p => p.PublicationGenres)
                .ThenInclude(p => p.Genre)
                .ToListAsync();
        }
    }
}