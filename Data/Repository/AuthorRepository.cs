using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class AuthorRepository : RepositoryBase<Author>
    {
        public AuthorRepository(DataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Author>> List()
        {
            return await DbSet
                .Include(p => p.AuthorGenres)
                .ThenInclude(p => p.Genre)
                .ToListAsync();
        }
    }
}