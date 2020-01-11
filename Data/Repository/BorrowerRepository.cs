using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class BorrowerRepository : RepositoryBase<Borrower>
    {
        public BorrowerRepository(DataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Borrower>> List()
        {
            return await DbSet
                .Include(p => p.Reservations)
                .ToListAsync();
        }
    }
}