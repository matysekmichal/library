using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Publication
    {
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        [DefaultValue(0)]
        public int Quantity { get; set; }
        public ICollection<PublicationGenre> PublicationGenres { set; get; }
        public ICollection<ReservedPublication> ReservedPublications { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Publication()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}