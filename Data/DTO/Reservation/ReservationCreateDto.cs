using System.Collections.Generic;

namespace Library.Data.DTO.Reservation
{
    public partial class ReservationCreateDto
    {
        public int BorrowerId { get; set; }
        public ICollection<int> PublicationsToReserve { get; set; }
    }
}