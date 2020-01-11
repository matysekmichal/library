using System;
using System.Collections.Generic;
using Library.Data.DTO.Borrower;
using Library.Data.DTO.Publication;
using Library.Models;

namespace Library.Data.DTO.Reservation
{
    public class ReservationListDto
    {
        public int Id { get; set; }
        public BorrowerListDto Borrower { get; set; }
        public ICollection<PublicationListDto> ReservedPublications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}