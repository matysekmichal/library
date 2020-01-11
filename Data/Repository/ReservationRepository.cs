using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class ReservationRepository : RepositoryBase<Reservation>
    {
        public ReservationRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Reservation>> List()
        {
            return await DbSet
                .Include(p => p.Borrower)
                .Include(p => p.ReservedPublications)
                .ThenInclude(p => p.Publication)
                .ToListAsync();
        }
    }
}