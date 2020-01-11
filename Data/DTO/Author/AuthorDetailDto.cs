
using System;
using System.Collections.Generic;
using Library.Data.DTO.Borrower;
using Library.Data.DTO.Genre;
using Library.Models;

namespace Library.Data.DTO.Author
{
    public class AuthorDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GenreDetailDto> AuthorGenres { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}