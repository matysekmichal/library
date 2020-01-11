using System;
using System.Collections.Generic;
using Library.Data.DTO.Borrower;
using Library.Data.DTO.Publication;

namespace Library.Data.DTO.Reservation
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }
        public BorrowerDetailDto Borrower { get; set; }
        public ICollection<PublicationDetailDto> ReservedPublications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}