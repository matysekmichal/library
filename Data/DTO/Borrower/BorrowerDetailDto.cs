using System;
using System.Collections.Generic;
using Library.Data.DTO.Reservation;

namespace Library.Data.DTO.Borrower
{
    public class BorrowerDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<ReservationDetailDto> Reservations { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}