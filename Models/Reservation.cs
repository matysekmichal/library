using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public ICollection<ReservedPublication> ReservedPublications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Reservation()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}