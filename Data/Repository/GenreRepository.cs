using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class GenreRepository : RepositoryBase<Genre>
    {
        public GenreRepository(DataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Genre>> List()
        {
            return await DbSet
                .Include(p => p.PublicationGenres)
                .ThenInclude(p => p.Publication)
                .Include(p => p.AuthorGenres)
                .ThenInclude(p => p.Author)
                .ToListAsync();
        }
    }
}