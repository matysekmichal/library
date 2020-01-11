using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class PublisherRepository : RepositoryBase<Publisher>
    {
        public PublisherRepository(DataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Publisher>> List()
        {
            return await DbSet
                .Include(p => p.Publications)
                .ToListAsync();
        }
    }
}